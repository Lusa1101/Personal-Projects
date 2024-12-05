using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMoneyPlanner.Models;

//Need to update this file to the standards of UnionRepo

namespace MyMoneyPlanner
{
    partial class ManagerPage : ContentPage
    {
        string finance = "Income";
        List<Income> incomes = new();
        List<Income> expense = new();
        public ManagerPage()
        {
            InitializeComponent();
        }

        public async void OnSubmitFinance(object sender, EventArgs e)
        {
            await DisplayAlert("Just confirmation", $"Selected is {finance}", "Okay");

            if (finance == "Expense")
            {
                Income expense = new Income();
                expense.Title = title.Text;
                expense.create_date();
                expense.modified_date();
                expense.Subtitle = subTitle.Text;
                expense.Type = "E";
                await App.repo.AddNewIncome(expense);

                await DisplayAlert("Confirmation", $"{App.repo.StatusMessage}", "Okay");
            }
            else if (finance == "Income")
            {
                Income income = new Income();
                income.Title = title.Text;
                income.create_date();
                income.modified_date();
                income.Type = "I";
                await App.repo.AddNewIncome(income);

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
            incomes = await App.repo.GetAllIncomes();
            incomes = incomes.Where(X => X.Type == "I").ToList();
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
