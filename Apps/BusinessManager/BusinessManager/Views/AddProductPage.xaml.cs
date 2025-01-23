using BusinessManager.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Views
{
    partial class AddPage : ContentPage
    {
        Data data = new Data();
        Functions functions = new Functions();
        Connect database = new Connect();

        //Lists
        List<Product> Products;
        List<Product_Category> Categories;
        List<Product_Subcategory> Subcategories;
        List<Product_Image> Images;
        List<Stock> Stocks;
        List<Stock_Receipt> Stock_Receipts;
        List<Package> Packages;
        List<Packaging> Packagings;
        List<Invoice> Invoices;
        List<Invoice_Line> Invoices_Lines;
        List<Essential> Essentials;

        //Selected Items
        Product_Category SelectedCategory;
        Product_Subcategory SelectedSubcategory;

        public AddPage()
        {
            InitializeComponent();
            BindingContext = this;

            List<String> categories = functions.ReturnNameArray(data.Subcategories);
            //categoriesFilter.ItemsSource = categories;

            Products = database.ReturnProducts();
            Categories = database.ReturnCategories();
            Subcategories = database.ReturnSubcategories();
            Stocks = database.ReturnStocks();
            Packages = database.ReturnPackages();
            Packagings = database.ReturnPackagings();
            Invoices = database.ReturnInvoices();
            Invoices_Lines = database.ReturnInvoiceLines();
            Essentials = database.ReturnEssentials();

            //Input checks
            packageQuantity.TextChanged += CheckIfQuantity;
            packageCost.TextChanged += CheckIfCost;
            productDescription.TextChanged += CheckDesciption;
        }


        /***    Tapped Handlers     ***/

        void OnCategoryTapped(object sender, TappedEventArgs e)
        {
            if (categoryLayout.IsVisible)
                categoryLayout.IsVisible = false;
            else
                categoryLayout.IsVisible = true;
        }

        void OnSubcategoryTapped(object sender, TappedEventArgs e)
        {
            if (subcategoryLayout.IsVisible)
                subcategoryLayout.IsVisible = false;
            else
                subcategoryLayout.IsVisible = true;

            //Refresh the category list
           // Categories = database.ReturnCategories();

            categoriesFilter.ItemsSource = Categories;
        }

        void OnPackageTapped(object sender, TappedEventArgs e)
        {
            if (packageLayout.IsVisible)
                packageLayout.IsVisible = false;
            else
                packageLayout.IsVisible = true;
        }

        void OnProductTapped(object sender, TappedEventArgs e)
        {
            if (productLayout.IsVisible)
                productLayout.IsVisible = false;
            else
                productLayout.IsVisible = true;

            productCategories.ItemsSource = Categories.ToList();
            productSubcategories.ItemsSource = Subcategories.ToList();
        }

        void OnEssentialTapped(object sender, TappedEventArgs e)
        {
            if (essentialLayout.IsVisible)
                essentialLayout.IsVisible = false;
            else
                essentialLayout.IsVisible = true;
        }

        /***    End Of Tapped Handlers     ***/

        /***    Add Handlers     ***/

        async void OnAddCategory(object sender, EventArgs e)
        {
            //Used for the id
            int number = 1;

            //The category to be inserted
            Product_Category category = new Product_Category();

            if (categoryEntry.Text != null && categoryEntry.Text.Length > 1)
            {
                //Get the last id to avoid duplicate values
                if (!Categories.IsNullOrEmpty())
                    number = functions.GetLastId(Categories);

                //Attaches @number to the id code
                category.Category_id = functions.CodeGenerator("Category", number);

                if (category.Category_id == "NULL")
                {
                    await DisplayAlert("Category", "Id was null", "Okay");
                    return;
                }

                category.Name = categoryEntry.Text;

                string result = database.InsertCategory(category);

                await DisplayAlert("Category", $"{result}", "Okay");

                //Make entry empty
                categoryEntry.Text = null;

                //Refresh the category list
                Categories = database.ReturnCategories();
            }
            else
            {
                await DisplayAlert("Category", "Please don't leave the entry empty.", "Okay");
            }

        }

        async void OnAddSubcategory(object sender, EventArgs e)
        {
            int number = 1;
            Product_Subcategory subcategory = new Product_Subcategory();

            if(subcategoryEntry.Text != null && subcategoryEntry.Text.Length > 1 && SelectedCategory != null)
            {
                if (!Subcategories.IsNullOrEmpty())
                    number = functions.GetLastId(Subcategories);

                subcategory.Subcategory_id = functions.CodeGenerator("Subcategory", number);

                if (subcategory.Subcategory_id == "NULL")
                {
                    await DisplayAlert("Subcategory", $"Id was null", "Okay");
                    return;
                }

                subcategory.Name = subcategoryEntry.Text;
                subcategory.Category_id = SelectedCategory.Category_id;

                string result = database.InsertSubcategory(subcategory);

                await DisplayAlert("Subcategory", $"{result}", "Okay");

                //Make nulls
                subcategoryEntry.Text = null;
                categoriesFilter.SelectedItem = null;

                //Refresh the list
                Subcategories = database.ReturnSubcategories();
            }
            else
            {
                await DisplayAlert("Subcategory", "Please don't leave the entry empty.", "Okay");
            }
        }

        async void OnAddPackage(object sender, EventArgs e)
        {
            int number = 1;
            Package package = new Package();

            if(functions.CheckEntry(packageSize) && functions.CheckEntry(packageName) && functions.CheckEntry(packageCost) && functions.CheckEntry(packageQuantity))
            {
                if (Packages is not null)
                    number = functions.GetLastId(Packages);

                package.Package_id = functions.CodeGenerator("Package", number);

                if (package.Package_id == "NULL")
                {
                    await DisplayAlert("Package", "Id was null", "Okay");
                    return;
                }

                package.Name = packageName.Text;
                package.Size = packageSize.Text;
                package.Cost = functions.DecimalConverter(packageCost.Text);
                package.Quantity = functions.IntegerConverter(packageQuantity.Text);

                string result = database.InsertPackage(package);

                if(result == "1")
                {
                    await DisplayAlert("Package", $"Package was successfully added.", "Okay");

                    //Set to null
                    functions.EntryToNull(packageQuantity);
                    functions.EntryToNull(packageCost);
                    functions.EntryToNull(packageSize);
                    functions.EntryToNull(packageName);

                    //Refresh the list
                    Packages = database.ReturnPackages();
                }
                else
                    await DisplayAlert("Package", $"{result}", "Okay");
            }
            else
            {
                await DisplayAlert("Package", "Please don't leave the entries empty.", "Okay");
            }
        }

        async void OnAddProduct(object sender, EventArgs e)
        {
            int number = 1;
            Product product = new Product();

            if (functions.CheckEntry(productName) && SelectedSubcategory != null && functions.CheckEntryLength(productDescription, 100))
            {
                if (!Products.IsNullOrEmpty())
                    number = functions.ReturnIndex(Products.LastOrDefault().Product_id);

                product.Product_id = functions.CodeGenerator("Product", number);

                if (product.Product_id == "NULL")
                {
                    await DisplayAlert("Product", "Id was null", "Okay");
                    return;
                }

                product.Name = productName.Text;
                product.Description = productDescription.Text;
                product.Subcategory_id = SelectedSubcategory.Subcategory_id;

                string result = database.InsertProduct(product);

                if (result == "1")
                {
                    await DisplayAlert("Product", "Product successfully added.", "Okay");

                    //Make entries null
                    productDescription.Text = null;
                    productName.Text = null;
                    productSubcategories.SelectedItem = null;

                    //Update the list
                    Products = database.ReturnProducts();
                }
                else
                {
                    await DisplayAlert("Product", $"{result}", "Okay");
                }
            }
            else if(!functions.CheckEntryLength(productDescription, 100))
                await DisplayAlert("Product", "Please make sure your descrption length does not exceed 100.", "Okay");
            else
            {
                await DisplayAlert("Product", "Please don't leave the Name empty and Subcategory unselected.", "Okay");
            }
        }

        async void OnAddEssential(object sender, EventArgs e)
        {
            Essential essential = new Essential();
            int number = 1;

            if (functions.CheckEntry(essentialName))
            {
                if (!Essentials.IsNullOrEmpty())
                    number = functions.GetLastId(Essentials);

                essential.Essential_id = number;

                essential.Name = essentialName.Text;

                string result = database.InsertEssential(essential);

                if (result == "1")
                {
                    await DisplayAlert("Essential", $"{result}", "Okay");

                    //make entry null
                    functions.EntryToNull(essentialName);
                }
                else
                    await DisplayAlert("Essential", result, "Okay");
            }
            else
                await DisplayAlert("Essential", "Ensure that you have entered a name", "Okay");
        }

        /***    End Of Add Handlers     ***/


        /***    Filter Handlers     ***/

        void OnProductSubcategorySelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;

            if (index != -1)
                SelectedSubcategory = (Product_Subcategory)picker.SelectedItem;

            //Making sure the subcategoryfilter is not visible
            subcategoryFilter.IsVisible = false;
        }

        void OnsubcategoryCategory(Object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;

            if (index != -1)
                SelectedCategory = Categories[index];

            Debug.WriteLine(SelectedCategory.Category_id + ": " + SelectedCategory.Name);
        }

        void OnProductCategorySelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;

            if (index != -1)
                SelectedCategory = Categories[index];

            //Making sure the subcategoryfilter is not visible
            subcategoryFilter.IsVisible = false;

            //Filter out the subcategory filter
            List<Product_Subcategory> list = new List<Product_Subcategory>();
            try
            {
                list = Subcategories.Where(s => s.Category_id == SelectedCategory.Category_id).ToList();
                productSubcategories.ItemsSource = list;
            }
            catch(Exception ex) 
            {
                subcategoryFilter.Text = ex.Message + "Please try selecting the category first.";
                subcategoryFilter.IsVisible = true;
            }

        }

        /***    End of Filter Handlers     ***/


        /***    Image Handlers     ***/
        async void OnAddProductImage(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick the related image",
                FileTypes = FilePickerFileType.Images
            });

            if (result == null)
            {
                await DisplayAlert("Upload Confirmation", "Your image was not uploaded properly. Try Again", "Close");
                return;
            }
            else
                await DisplayAlert("Upload Confirmation", "Your image was successfully uploaded.", "Close");

            productImage.Text = result.FullPath;
        }
            /***    End of Image Handlers     ***/


        /***        Input Checks        ***/

        void CheckIfCost(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Any(c => char.IsDigit(c)) || e.NewTextValue.Any(c => c == '.') || e.NewTextValue.Any(c => c == ','))
            {
                cost.IsVisible = false;
            }
            else if(packageCost.Text.Length > 0)
            {
                cost.Text = "Please enter a decimal value.";
                cost.IsVisible = true;
            }
            else
                cost.IsVisible = false;
        }
        void CheckIfQuantity(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Any(c => char.IsDigit(c)) || packageQuantity.Text.Length == 0)
            {
                quantity.IsVisible = false;
            }
            else
            {
                quantity.Text = "Please enter an integer value";
                quantity.IsVisible = true;
            }
        }

        void CheckDesciption(object sender, TextChangedEventArgs e)
        {
            if(productDescription.Text.Length > 100)
            {
                descriptionCheck.IsVisible = true;
                descriptionCheck.Text = $"Characters exceed 100, please reduce the number of characters. Current number({productDescription.Text.Length}).";
            }
            else
                descriptionCheck.IsVisible = false;
        }
        /***        End of Input Checka     ***/
    }
}
