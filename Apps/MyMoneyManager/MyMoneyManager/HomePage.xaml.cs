//HomePage.xaml.cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using MyMoneyManager.Models;

namespace MyMoneyManager
{
    partial class HomePage : ContentPage
    {
        decimal _actual_amount { get; set; } = 0m;
        decimal _planned_amount { get; set; } = 0m;

        //bools to handle displays
        bool incomeDisplayed = false;
        bool expenseDisplayed = false;

        //To get the income list
        List<Union> incomes = new();
        List<Union> expenses = new();

        //string to handle submission form
        string finance = "Income";

        public HomePage()
        {
            InitializeComponent();

            GetAmounts();
            GetAll();

        }

        async void GetAll()
        {
            incomes = await App.repo.GetAllEntries();
            incomes = incomes.Where(x => x.Type == 'I').ToList();

            expenses = await App.repo.GetAllEntries();
            expenses = expenses.Where(x => x.Type == 'E').ToList();
        }

        public async void OnIncomeSelected(Object sender, SelectionChangedEventArgs e)
        {
            //To deselect the item
            incomeList.SelectedItem = null;

            Union? selectedIncome = (e.CurrentSelection.FirstOrDefault() as Union);

            if (selectedIncome != null)
                await Navigation.PushAsync(new EditorPage("income", selectedIncome.Id));
        }

        public void OnIncomeDisplay(object sender, TappedEventArgs e)
        {
            if (!incomeDisplayed)
            {
                incomeDisplayed = true;

                //Assign the collection view with the source
                incomeList.ItemsSource = incomes;

                //To check if there its not null
                foreach (Union income in incomes)
                {
                    Debug.WriteLine(income.Title);
                }
            }
            else
            {
                incomeDisplayed = false;
                incomeList.ItemsSource = new List<Union>();
            }

            //Initiatiate the GetAmounts()
            GetAmounts();

        }

        public void OnExpenseDisplay(object sender, TappedEventArgs e)
        {
            if (!expenseDisplayed)
            {
                expenseDisplayed = true;

                //Assign the collection view with the source
                expenseList.ItemsSource = expenses;

                //To check if there its not null
                foreach (Union expense in expenses)
                {
                    Debug.WriteLine(expense.Subtitle);
                }
            }
            else
            {
                expenseDisplayed = false;
                expenseList.ItemsSource = new List<Union>();
            }
        }

        public async void OnExpenseSelected(object sender, SelectionChangedEventArgs e)
        {
            //To deselect the item
            incomeList.SelectedItem = null;

            Union? selectedExpense = (e.CurrentSelection.FirstOrDefault() as Union);

            if (selectedExpense != null)
                await Navigation.PushAsync(new EditorPage("expense", selectedExpense.Id));
        }

        public async void OnSubmitFinance(object sender, EventArgs e)
        {
            await DisplayAlert("Just confirmation", $"Selected is {finance}", "Okay");

            if (finance == "Expense" && title.Text.Length > 0)
            {
                Union expense = new Union();
                expense.Title = title.Text.ToUpper();
                expense.create_date();
                expense.modified_date();
                expense.Subtitle = subTitle.Text.ToUpper();
                expense.Type = 'E';
                expense.Planned_amount = 0m;
                expense.Actual_amount = 0m;
                await App.repo.AddNewEntry(expense);

                await DisplayAlert("Confirmation", $"{App.repo.StatusMessage}", "Okay");
            }
            else if (finance == "Income" && title.Text.Length > 0)
            {
                Union income = new Union();
                income.Title = title.Text.ToUpper();
                income.create_date();
                income.modified_date();
                income.Type = 'I';
                income.Actual_amount = 0m;
                income.Planned_amount = 0m;
                await App.repo.AddNewEntry(income);

                await DisplayAlert("Confirmation", App.repo.StatusMessage, "Okay");
            }
            else
                await DisplayAlert("Confirmation", "Nothing was added.", "Okay");
        }

        public void OnExpenseCheck(object sender, CheckedChangedEventArgs e)
        {
            if (subTitle.IsVisible == false)
            {
                subTitle.IsVisible = true;
                finance = "Expense";
            }
            else
            {
                subTitle.IsVisible = false;
                finance = "Income";
            }
        }

        async void GetAmounts()
        {
            incomes = await App.repo.GetAllEntries();

            expenses = incomes.Where(x => x.Type == 'E').ToList();
            incomes = incomes.Where(x => x.Type == 'I').ToList();

            decimal a_sum = 0;
            decimal p_sum = 0;


            //For the incomes
            foreach (var income in incomes)
            {
                a_sum += income.Actual_amount;
                p_sum += income.Planned_amount;
            }
            incomeActualTotal.Text = a_sum.ToString("0.00");
            incomePlannedTotal.Text = p_sum.ToString("0.00");

            //For expenses
            a_sum = 0m;
            p_sum = 0;
            foreach (Union expense in expenses)
            {
                a_sum += expense.Actual_amount;
                p_sum += expense.Planned_amount;
            }
            expensePlannedTotal.Text = p_sum.ToString("0.00");
            expenseActualTotal.Text = a_sum.ToString("0.00");
        }
    }
}