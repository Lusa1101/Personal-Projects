//Section/Edit.xaml.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMoneyManager.Models;

namespace MyMoneyManager
{
    partial class EditorPage : ContentPage
    {
        string _type = string.Empty;
        int _id = 0;
        Union? income = new Union();
        Union? expense = new Union();
        public EditorPage(string type, int id)
        {
            InitializeComponent();

            _type = type;
            _id = id;

            LayoutUpload();
        }

        async void LayoutUpload()
        {
            if (this._type == "income")
            {
                List<Union> incomes = await App.repo.GetAllEntries();
                income = incomes.Where(i => i.Id == _id).FirstOrDefault();

                if (income != null)
                {
                    l_title.Text = income.Title;
                    p_amount.Placeholder = income.Planned_amount.ToString("0.00");
                    a_amount.Placeholder = income.Actual_amount.ToString("0.00");

                }
            }
            else if (this._type == "expense")
            {
                List<Union> expenses = await App.repo.GetAllEntries();
                Union? expense = expenses.Where(e => e.Id == _id).FirstOrDefault();

                if (expense != null)
                {
                    l_title.Text = expense.Subtitle;
                    p_amount.Placeholder = expense.Planned_amount.ToString("0.00");
                    a_amount.Placeholder = expense.Actual_amount.ToString("0.00");

                }
            }
            else
                await Navigation.PopAsync();
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            if (this._type == "income" && income != null)
            {
                await App.repo.Delete(income);

                await DisplayAlert("Delete", App.repo.StatusMessage, "Okay");

                await Navigation.PopAsync();
            }
            else if (this._type == "expense" && expense != null)
            {
                await App.repo.Delete(expense);

                await DisplayAlert("Delete", App.repo.StatusMessage, "Okay");

                await Navigation.PopAsync();
            }
        }
        public async void OnSaveChanges(object sender, EventArgs e)
        {
            if (this._type == "income" && income != null)
            {
                //Assigning the new value to the this.income
                if (p_amount.Text != null)
                    income.Planned_amount = DecimalConverter(p_amount.Text);

                if (a_amount.Text != null)
                    income.Actual_amount = DecimalConverter(a_amount.Text);

                await App.repo.Update(income);

                await DisplayAlert("Update", App.repo.StatusMessage, "Okay");

                await Navigation.PopAsync();
            }
            else if (this._type == "expense" && expense != null)
            {
                //Assigning the expense with new values                                
                if (p_amount.Text != null)
                    expense.Planned_amount = DecimalConverter(p_amount.Text);

                if (a_amount.Text != null)
                    expense.Actual_amount = DecimalConverter(a_amount.Text);

                await App.repo.Update(expense);

                await DisplayAlert("Update", App.repo.StatusMessage, "Okay");

                await Navigation.PopAsync();
            }
        }

        decimal DecimalConverter(string temp)
        {
            if (temp.Contains(","))
                temp = temp.Replace(",", ".");

            var culture = CultureInfo.InvariantCulture;
            return decimal.Parse(temp, culture);
            // return Convert.ToDecimal(temp);
        }


        public async void OnExitEditor(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}