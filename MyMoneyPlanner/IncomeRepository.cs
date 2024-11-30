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
    public class IncomeRepository
    {
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
                await connection.CreateTableAsync<Income>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                StatusMessage = ex.Message;
            }
        }

        public IncomeRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task RunQuery()
        {
            int result;
            try
            {
                await Init();

                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                //result = await connection.ExecuteAsync("ALTER TABLE income ADD SUBTITLE VARCHAR(50)");
                //result = await connection.ExecuteAsync("ALTER TABLE income ADD Type CHAR(1)");                
                //result = await connection.ExecuteAsync("ALTER TABLE income RENAME COLUMN income_id TO ID;");

                //result = await connection.ExecuteAsync("UPDATE income SET Title=\"BN1\" WHERE Id = 8");
                result = 0;

                StatusMessage = string.Format("Successfully ran the query(rENAMING).");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("{0} Failed to add. \n",ex.Message);
            }
        }

        public async Task AddNewIncome(Income income)
        {
            int result;
            try
            {
                await Init();

                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (income.Title == null)
                    throw new Exception("The entry is invalid.");

                result = await connection.InsertAsync(income);

                if (income.Type == "I")
                    StatusMessage = string.Format("{0} Successfully added {1}", result, income.Title);
                else
                    StatusMessage = string.Format("{0} Successfully added {1}", result, income.Subtitle);
            }
            catch (Exception ex)
            {
                if(income.Type != "I")
                    StatusMessage = string.Format("{0} Failed to add. \n{1}", income.Subtitle, ex.Message);
                else
                    StatusMessage = string.Format("{0} Failed to add. \n{1}", income.Title, ex.Message);
            }
        }

        /*
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
        */

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
                return await connection.QueryAsync<Income>("SELECT * FROM income");
                //StatusMessage = string.Format("All incomes retrieved {0}", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to abstract incomes.\n{0}",ex.Message);
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
                
                if(income.Type == "I")
                    StatusMessage = string.Format("{0}: Successfully Deleted {1}", result, income.Title);
                else
                    StatusMessage = string.Format("{0}: Successfully Deleted {1}", result, income.Subtitle);
            }
            catch (Exception ex)
            {
                if(income.Type != "I")
                    StatusMessage = string.Format("Failed to delete {0}. \n{1}", income.Subtitle, ex.Message);
                else
                    StatusMessage = string.Format("Failed to delete {0}. \n{1}", income.Title, ex.Message);
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

                if(income.Type == "I")
                    StatusMessage = string.Format("Update for {0} was successful.", income.Title);
                else
                    StatusMessage = string.Format("Update for {0} was successful.", income.Subtitle);
            }
            catch (Exception ex)
            {
                if(income.Type != "I")
                    StatusMessage = string.Format("{0} \nFailed to update {1}", ex.Message, income.Subtitle);
                else
                    StatusMessage = string.Format("{0} \nFailed to update {1}", ex.Message, income.Title);
            }
        }

        
    }
}
