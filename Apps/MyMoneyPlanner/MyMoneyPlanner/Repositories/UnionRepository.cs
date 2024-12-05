using System;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMoneyPlanner.Models;
using System.Diagnostics;

namespace MyMoneyPlanner.Repositories
{
    public class UnionRepository
    {
        string? _dbPath;
        public string StatusMessage = "Nothing Changed.";
        private SQLiteAsyncConnection? connection;

        private async Task Init()
        {
            /*
            if (connection is not null)
            {
                StatusMessage = "Connection was not null.";
                Debug.WriteLine(StatusMessage);
                return;
            }
            */
            try
            {
                connection = new SQLiteAsyncConnection(Constants.dbPath, Constants.Flags);
                await connection.CreateTableAsync<Union>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                StatusMessage = ex.Message;
            }
        }

        public UnionRepository(string dbPath)
        {
            _dbPath = dbPath;

            Debug.WriteLine($"{dbPath}");
        }

        public async Task AddNewEntry(Union entry)
        {
            int result;
            try
            {
                await Init();

                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (entry == null)
                    throw new Exception("The income is invalid.");

                result = await connection.InsertAsync(entry);
                StatusMessage = string.Format("{0} Successfully added {1}", result, entry.Title);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("{0} Failed to add. \n{1}", entry.Title, ex.Message);
            }
        }

        
        public async Task<Union> GetIncome(int id)
        {
            try
            {
                await Init();
                if (connection is null)
                    throw new Exception("Connection to the database wasnot established.");

                if (id == 0)
                    throw new Exception("The id is invalid");

                return  await connection.Table<Union>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve income with id {0}", id);
            }

            return new Union();
        }
        

        public async Task<List<Union>> GetAllEntries()
        {
            int result = 0;
            List<Union> entries = new();
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                entries = await connection.Table<Union>().ToListAsync();
                StatusMessage = string.Format("All incomes retrieved {0}", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to abstract incomes.\n{0}", ex.Message);
            }
            return entries;
        }

        public async Task<int> Delete(Union entry)
        {
            int result = 0;
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (entry == null)
                    throw new Exception("No income provided.");

                result = await connection.DeleteAsync(entry);

                if(entry.Subtitle != null)
                    StatusMessage = string.Format("{0}: Successfully Deleted {1}", result, entry.Subtitle);
                else
                    StatusMessage = string.Format("{0}: Successfully Deleted {1}", result, entry.Title);

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. \n{1}", entry.Title, ex.Message);
            }
            return result;
        }

        public async Task Update(Union entry)
        {
            //int result = 0;
            try
            {
                await Init();
                if (connection == null)
                    throw new Exception("Connection to the database was not established.");

                if (entry is null)
                    throw new Exception("No id provided.");
                await connection.UpdateAsync(entry);
                //await connection.QueryAsync<Income>($"UPDATE income SET Amount = {income.amount} WHERE income_id = { income.income_id }" );

                if (entry.Subtitle != null)
                    StatusMessage = string.Format("Update for {0} was successful.", entry.Subtitle);
                else
                    StatusMessage = string.Format("Update for {0} was successful.", entry.Title);
            }
            catch (Exception ex)
            {
                if(entry.Subtitle == null)
                    StatusMessage = string.Format("{0} \nFailed to update {1}", ex.Message, entry.Title);
                else
                    StatusMessage = string.Format("{0} \nFailed to update {1}", ex.Message, entry.Subtitle);
            }
        }
    }
}
