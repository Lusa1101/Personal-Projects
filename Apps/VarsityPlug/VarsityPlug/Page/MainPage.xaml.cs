using System.Linq.Expressions;
using System.Diagnostics;
using VarsityPlug.Models;

namespace VarsityPlug
{
    public partial class MainPage : ContentPage
    {
        public bool isBuyer = true;
        Connect data = new Connect();
        public Person currentUser { get; set; }
        public MainPage()
        {
            InitializeComponent();

            data.CreateConnection();

            /*
            Connect connect = new Connect();
            try
            {
                connect.CreateCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            */
        }

        async void GoToSignupPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        void OnUserMode(object sender, CheckedChangedEventArgs e) 
        {
            if (e.Value)
                isBuyer = true;
            else
                isBuyer = false;
        }

        void OnPasswordEye(object sender, EventArgs e)
        {
            if (password.IsPassword == false)
            {
                passwordEye.Source = "icons8_eye.png";
                password.IsPassword = true;
            }

            else
            {
                passwordEye.Source = "icons8_closed_eye.png";
                password.IsPassword = false;

            }
        }

        public int Verification(string username,string password)
        {
            List<Person> people = data.ReturnPeople();
            //Person? person = people.FirstOrDefault(p => p.Id.ToString() == username);
            Person person = data.ReturnPerson(username);

            if (person == null)
                Debug.WriteLine($"Person {username} in Login Page is null");
            else
                Debug.WriteLine($"{person.Name}");

            if (person == null)
                return 315;
            if (person.Password == password)
            {
                currentUser = person;
                return 515;                
            }
            return 827;
        }

        async void OnSignIn(object sender, EventArgs e)
        {
            int pass = Verification(username.Text, password.Text);
            signinHandler.Text = "";
            signinHandler.IsVisible = true;
            switch (pass)
            {
                case 315:
                    signinHandler.Text = "Please register!";
                    break;
                case 827:
                    signinHandler.Text = "Password incorrect!";
                    break;
                case 515:
                    if (isBuyer)
                        await Navigation.PushAsync(new HomePage(username.Text));
                    else
                        await Navigation.PushAsync(new SellerHomePage());
                    break;
            }
            /*
            if (true)
            {
                signinHandler.IsVisible = false;

                if(isBuyer)
                    await Navigation.PushAsync(new HomePage());
                else
                    await Navigation.PushAsync(new SellerHomePage());
            }
            
            signinHandler.IsVisible = true;
            */
        }

    }

}
