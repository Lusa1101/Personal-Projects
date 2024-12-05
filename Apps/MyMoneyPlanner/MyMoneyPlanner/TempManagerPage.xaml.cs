using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using MyMoneyPlanner.Models;

namespace MyMoneyPlanner
{
    partial class TempManagerPage : ContentPage
    {
        //bools to handle displays
        bool incomeDisplayed = false;
        bool expenseDisplayed = false;

        //To get the income list
        List<Income> incomes = new();
        List<Income> expenses = new();
        List<string> ExpenseTypes = new();

        //string to handle submission form
        string finance = "Income";
        string selectedExpense = String.Empty;

        public TempManagerPage()
        {
            InitializeComponent();

            GetAmounts();
            GetAll();

            ExpenseTypes.Add("Basic Needs");
            ExpenseTypes.Add("Insurances");
            ExpenseTypes.Add("Clothing");
            ExpenseTypes.Add("Other");
            expenseTitle.ItemsSource = ExpenseTypes;

            //To deselect the item
            incomeList.ItemsSource = new List<Income>();
            expenseList.ItemsSource = new List<Income>();

        }

        async void GetAll()
        {
            incomes = await App.repo.GetAllIncomes();

            foreach (var income in incomes)
                Debug.WriteLine($"{income.Id}   | {income.Type} | {income.Title} | {income.Subtitle}");

            incomes = incomes.Where(x => x.Type == "I").ToList();

            expenses = await App.repo.GetAllIncomes();
            expenses = expenses.Where(x => x.Type == "E").ToList();
        }

        public async void OnIncomeSelected(Object sender, SelectionChangedEventArgs e)
        {
            Income? selectedIncome = (e.CurrentSelection.FirstOrDefault() as Income);

            if (selectedIncome != null)
                await Navigation.PushAsync(new EditorPage("income", selectedIncome.Id));
        }

        public void OnIncomeDisplay(object sender, TappedEventArgs e)
        {
            if(!incomeDisplayed)
            {
                incomeDisplayed = true;

                //Assign the collection view with the source
                incomeList.ItemsSource = incomes;

                //To check if there its not null
                foreach (Income income in incomes)
                {
                    Debug.WriteLine(income.Title);
                }
            }
            else
            {
                incomeDisplayed = false;
                incomeList.ItemsSource = new List<Income>();
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
                foreach (Income expense in expenses)
                {
                    Debug.WriteLine(expense.Subtitle);
                }
            }
            else
            {
                expenseDisplayed = false;
                expenseList.ItemsSource = new List<Expense>();
            }

            //Initiatiate the GetAmounts()
            GetAmounts();
        }

        public async void OnExpenseSelected(object sender, SelectionChangedEventArgs e)
        {
            Income? selectedExpense = (e.CurrentSelection.FirstOrDefault() as Income);

            if (selectedExpense != null)
                await Navigation.PushAsync(new EditorPage("expense", selectedExpense.Id));
        }

        void OnExpenseTypeChaged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex < 0)
            {
                Debug.WriteLine("Index less the zero");
            }
            else
                selectedExpense = ExpenseTypes[selectedIndex];
            
            Debug.WriteLine($"Selected expense type chaged {selectedExpense}");
        }

        public async void OnSubmitFinance(object sender, EventArgs e)
        {
            if (finance == "Expense" && subtitle.Text != null && selectedExpense != String.Empty)
            {
                Income expense = new Income();
                expense.Title = GetTheExpenseTitle(selectedExpense, GetHighestID()).ToUpper();
                expense.create_date();
                expense.modified_date();
                expense.Subtitle = subtitle.Text.ToUpper();
                expense.Type = "E";
                expense.Planned_amount = 0m;
                expense.Actual_amount = 0m;

                await App.repo.AddNewIncome(expense);

                //clear the entir
                expenseTitle.SelectedItem = null;
                subtitle.Text = null;

                await DisplayAlert("Confirmation", $"{App.repo.StatusMessage}", "Okay");
            }
            else if (finance == "Income" && title.Text != null)
            {
                Income income = new Income();
                income.Title = title.Text.ToUpper();
                income.create_date();
                income.modified_date();
                income.Type = "I";
                income.Actual_amount = 0m;
                income.Planned_amount = 0m;

                await App.repo.AddNewIncome(income);

                //Clear the entries
                title.Text = null;

                await DisplayAlert("Confirmation", App.repo.StatusMessage, "Okay");
            }
            else
                await DisplayAlert("Confirmation", "Nothing was added.", "Okay");
        }

        string GetTheExpenseTitle(string expenseType, int id)
        {
            switch(expenseType)
            {
                case "Basic Needs":
                    return $"BN{id}";
                case "Insurances":
                    return $"I{id}";
                case "Clothing":
                    return $"C{id}";
                default:
                    return $"O{id}";
            }                       
        }

        int GetHighestID()
        {
            try
            {
                Income temp = expenses.Last();
                return temp.Id;
            }
            catch 
            {
                return 1;
            }            
        }

        public void OnExpenseCheck(object sender, CheckedChangedEventArgs e)
        {
            if (expenseTitle.IsVisible == false)
            {
                //Reset the entries for expense
                expenseTitle.SelectedItem = null;
                subtitle.Text = null;

                expenseTitle.IsVisible = true;
                subtitle.IsVisible = true;
                title.IsVisible = false;
                finance = "Expense";
            }
            else
            {
                //reset entry for income
                title.Text = null;

                expenseTitle.IsVisible = false;
                subtitle.IsVisible = false;
                title.IsVisible = true;
                finance = "Income";
            }
        }

        async void GetAmounts()
        {
            incomes = await App.repo.GetAllIncomes();

            expenses = incomes.Where(x => x.Type == "E").ToList();
            incomes = incomes.Where(x => x.Type == "I").ToList();

            decimal a_sum = 0;
            decimal p_sum = 0;


            //For the incomes
            foreach (var income in incomes)
            {
                a_sum += income.Actual_amount;
                p_sum += income.Planned_amount;
            }
            incomeActualTotal.Text = "Actual: " + a_sum.ToString("0.00");
            incomePlannedTotal.Text = "Planned: " + p_sum.ToString("0.00");

            //Totals for income
            incomeActual.Text = returnString(incomeActualTotal.Text);
            incomePlanned.Text = returnString(incomePlannedTotal.Text);

            //For expenses
            a_sum = 0;
            p_sum = 0;
            foreach(var expense in expenses)
            {
                a_sum += expense.Actual_amount;
                p_sum += expense.Planned_amount;
            }
            expensePlannedTotal.Text = "Planned: "  + p_sum.ToString("0.00");
            expenseActualTotal.Text = "Actual: " + a_sum.ToString("0.00");

            //Totals for expense
            expenseActual.Text = returnString(expenseActualTotal.Text);
            expensePlanned.Text = returnString(expensePlannedTotal.Text);
            
            //Totals differences
            plannedDiff.Text = (decimal.Parse(returnString(incomePlannedTotal.Text)) - decimal.Parse(returnString(expensePlannedTotal.Text))).ToString("0.00");
            actualDiff.Text = (decimal.Parse(returnString(incomeActualTotal.Text)) - decimal.Parse(returnString(expenseActualTotal.Text))).ToString("0.00");

        }

        private string returnString(string str)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == ':' && str[i+1] == ' ')
                {
                    i += 2;

                    for (int j = i; j < str.Length; j++)
                        sb.Append(str[j]);

                    break;
                }
            }

            return sb.ToString();
        }
    }
}
