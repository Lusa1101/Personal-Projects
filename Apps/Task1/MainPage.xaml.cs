using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;

namespace Task1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSubmitClient(object sender, EventArgs e)
        {
            
        }
    }

    public partial class ClientViewModel : ObservableObject
    {
        //DB
        Database db = new();

        //Command for insert button
        public ICommand InsertCommand { get; set; }

        //The client list
        [ObservableProperty]
        ObservableCollection<Client> clients = new();

        //For the inputs
        [ObservableProperty]
        string name = string.Empty;
        [ObservableProperty]
        string cell = string.Empty;
        [ObservableProperty]
        string address = string.Empty;

        public ClientViewModel()
        {
            //List
            Update();

            //For the commamd
            InsertCommand = new Command(async () => await Insert());
        }

        //Function for inserting
        async Task Insert()
        {
            Client client = new Client();

            if (Name != string.Empty && Name.Length > 0 &&
                Address != string.Empty && Address.Length > 0 &&
                Cell != string.Empty && Cell.Length > 0)
            {
                //Copy the input to the client variable
                client.Name =   Name;
                client.Address = Address;
                client.Phone_Number = Cell;
                client.Client_id = Clients.Max(c => c.Client_id) + 1;

                //Add to the list
                var output = await db.InsertClient(client);

                //Update the list
                await Update();

                //Nullify the entries
                Name = string.Empty;
                Address = string.Empty;
                Cell = string.Empty;
            }
        }

        //Data
        async Task Update()
        {
            var temp = new List<Client>
            {
                new Client { Client_id = 83774873, Name = "Omphulusa", Phone_Number = "0782938928", Address = "Address 1" },
                new Client { Client_id = 82773883, Name= "Ndivhuwo", Phone_Number = "0783672893", Address = "Address 2" }
            };

            var list = await db.GetClients();

            Clients = new ObservableCollection<Client>(list);
        }
    }

    public class Client
    {
        public Client ()
        {

        }

        public int Client_id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone_Number { get; set; } = string.Empty;

    }

    public class Database
    {
        HttpClient client = new HttpClient();
        public Database()
        {
            //use ip address if external devices are used
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
                client.BaseAddress = new Uri("https://localhost:7069/api/");
            else
                client.BaseAddress = new Uri("https://192.168.56.1:7069/api/");
        }

        public async Task<List<Client>> GetClients()
        {
            var response = await client.GetAsync("Client/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Client>>(data); // Deserialize JSON to your model

                if (list is not null)
                return list.ToList();// Use the products list in your app
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}");
            }

            return new();
        }

        public async Task<string> InsertClient(Client client)
        {
            var json_content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");

            try
            {
                var responce = await this.client.PostAsync("Client/AddNewClient", json_content);
                var responceBody = await responce.Content.ReadAsStringAsync();

                return responceBody;
            }
            catch (Exception e)
            {
                return ("Inserting new client:\n" + e.Message);
            }
        }
    }

}
