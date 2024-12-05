//ManagerPage.xaml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMoneyManager.Models;

//Need to update this file to the standards of UnionRepo

namespace MyMoneyManager
{
    partial class ManagerPage : ContentPage
    {
        string finance = "Income";
        List<Union> incomes = new();
        List<Union> expense = new();
        public ManagerPage()
        {
            InitializeComponent();
        }

        public async void OnSubmitFinance(object sender, EventArgs e)
        {
            await DisplayAlert("Just confirmation", $"Selected is {finance}", "Okay");

            if (finance == "Expense")
            {
                Union expense = new Union();
                expense.Title = title.Text;
                expense.create_date();
                expense.modified_date();
                expense.Subtitle = subTitle.Text;
                expense.Type = 'E';
                await App.repo.AddNewEntry(expense);

                await DisplayAlert("Confirmation", $"{App.repo.StatusMessage}", "Okay");
            }
            else if (finance == "Income")
            {
                Union income = new Union();
                income.Title = title.Text;
                income.create_date();
                income.modified_date();
                income.Type = 'I';
                await App.repo.AddNewEntry(income);

                await DisplayAlert("Confirmation", App.repo.StatusMessage, "Okay");
            }
            else
                await DisplayAlert("Confirmation", App.repo.StatusMessage, "Okay");
        }

        public void OnExpenseSelected(object sender, CheckedChangedEventArgs e)
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

        void OnRemoveIncome(object sender, EventArgs e)
        {
            Union income = (Union)sender;
            DisplayAlert("Checking", income.Title, "Okay");
        }

        void OnEditIncome(object sender, EventArgs e)
        {

        }

        async void OnIncomeDisplay(object sender, TappedEventArgs e)
        {
            incomes = await App.repo.GetAllEntries();
            decimal planned_sum = 0m;
            decimal actual_sum = 0m;

            foreach (var income in incomes)
            {
                planned_sum += income.Planned_amount;
                actual_sum += income.Actual_amount;
            }
            IncomeCollection.ItemsSource = incomes;
            incomeActualTotal.Text = actual_sum.ToString();
            incomePlannedTotal.Text = planned_sum.ToString();
        }

        void OnExpenseDisplay(object sender, TappedEventArgs e)
        {

        }
    }
}