using CommunityToolkit.Mvvm.ComponentModel;
using BusinessManager.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace BusinessManager.ViewModels
{
    public partial class InvoiceSummaryViewModel : ObservableObject
    {
        Connect database = new();
        Functions functions = new Functions();
        List<DisplayProduct> _products = new();
        public ObservableCollection<DisplayProduct> Products { get; set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand ReduceCommand { get; private set; }

        decimal _total { get; set; }
        public decimal Total
        {
            get
            {
                RefreshTotal();
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        public InvoiceSummaryViewModel()
        {
            Products = [];
            DeleteCommand = new Command<DisplayProduct>(Delete);
            AddCommand = new Command<DisplayProduct>(Add);
            ReduceCommand = new Command<DisplayProduct>(Reduce);
        }

        void Reduce(DisplayProduct product)
        {
            var prod = Products.FirstOrDefault(p => p.Stock_id == product.Stock_id);
            if (prod != null)
            {
                if (prod.Quantity > 1)
                {
                    prod.Quantity -= 1;
                }
                else
                    Delete(product);
            }
        }

        void Add(DisplayProduct product)
        {
            var prod = Products.FirstOrDefault(p => p.Stock_id == product.Stock_id);
            if (prod != null)
            {
                prod.Quantity += 1;
            }
        }
        void Delete(DisplayProduct product)
        {
            if (Products.Contains(product))
            {
                Products.Remove(product);
            }
            RefreshTotal();
        }

        public void RefreshList()
        {
            _products = database.ReturnDisplayProducts(true);
            _products.AddRange(database.ReturnDisplayProducts(false));
            Products = new ObservableCollection<DisplayProduct>(_products);
        }
        public void UpdateList(List<DisplayProduct> list)
        {
            _products = list;
        }

        public void OnProductsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RefreshTotal();
        }

        public void RefreshTotal()
        {
            _total = Products.Sum(p => p.Price * p.Quantity);
        }
    }
}
