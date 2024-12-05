using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MyMoneyPlanner.Models;
using System.Diagnostics;

namespace MyMoneyPlanner.Repositories
{
    public class ExpenseRepository
    {
        /*
        string? _dbPath;
        public string StatusMessage = "Nothing Changed.";
        private SQLiteAsyncConnection? connection;

        private async Task Init()
        {
            if (connection != null)
            {
                StatusMessage = "Connection was null.";
                return;
            }

            try
            {
                connection = new SQLiteAsyncConnection(_dbPath);
                await connection.CreateTableAsync<Expense>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                StatusMessage = ex.Message;
            }
        }

        public ExpenseRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewIncome(Income income)
        {
            int result;
            try
            {
                await Init();

                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (income.title == null)
                    throw new Exception("The income is invalid.");

                result = await connection.InsertAsync(income);
                StatusMessage = string.Format("{0} Successfully added {1}", result, income.title);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("{0} Failed to add. \n{1}", income.title, ex.Message);
            }
        }

        
        public async Task<Income> GetIncome(int id)
        {
            Income income;
            try
            {
                await Init();
                if (id == 0)
                    throw new Exception("The id is invalid");
                return await connection.Table<Income>().Where(i => i.income_id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve income with id {0}", id);
            }
            return income;
        }
        

        public async Task<List<Income>> GetAllIncomes()
        {
            int result = 0;
            List<Income> incomes = new List<Income>();
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                incomes = await connection.Table<Income>().ToListAsync();
                StatusMessage = string.Format("All incomes retrieved {0}", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to abstract incomes.\n{0}", ex.Message);
            }
            return incomes;
        }

        public async Task<int> Delete(Income income)
        {
            int result = 0;
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (income == null)
                    throw new Exception("No income provided.");

                result = await connection.DeleteAsync(income);
                StatusMessage = string.Format("{0}: Successfully Deleted {1}", result, income.title);

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. \n{1}", income.title, ex.Message);
            }
            return result;
        }

        public async Task Update(Income income)
        {
            //int result = 0;
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (income is null)
                    throw new Exception("No id provided.");
                await connection.UpdateAsync(income);
                //await connection.QueryAsync<Income>($"UPDATE income SET Amount = {income.amount} WHERE income_id = { income.income_id }" );

                StatusMessage = string.Format("Query was successfully.");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("{0} \nFailed to update {1}", ex.Message, income.title);
            }
        }

        public async Task AddNewExpense(Expense expense)
        {
            int result;
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (expense == null)
                    throw new Exception("The expense is null.");

                result = await connection.InsertAsync(expense);
                StatusMessage = string.Format("{0} Successfully added {1}", result, expense.title);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("{0} Failed to add. \n{1}", expense.title, ex.Message);
            }
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
            List<Expense> result = new List<Expense>();
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                result = await connection.Table<Expense>().ToListAsync();

                StatusMessage = string.Format("Successfully retrieved the expenses");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to abstract incomes. \n{0}", ex.Message);
            }
            return result;
        }

        public async Task<int> Delete(Expense expense)
        {
            int result = 0;
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (expense == null)
                    throw new Exception("No expense provided.");

                result = await connection.DeleteAsync(expense);

                StatusMessage = string.Format("Successfully deleted the {0}", expense.subtitle);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. \n{1}", expense.subtitle, ex.Message);
            }
            return result;
        }

        public async Task Update(Expense expense)
        {
            //int result = 0;
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (expense is null)
                    throw new Exception("No id provided.");
                await connection.UpdateAsync(expense);
                //await connection.QueryAsync<Income>($"UPDATE income SET Amount = {expense.amount} WHERE income_id = {expense.expense_id}");

                StatusMessage = string.Format("Successfully updated {0}", expense.subtitle);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. \n{1}", expense.subtitle, ex.Message);
            }
        }
        */
    }
}
