using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Models;

namespace ToDo.App.Data
{
    public class DatabaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public DatabaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<ToDoItem>().Wait();
        }

        public async Task<int> InsertItemAsync(ToDoItem item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<List<ToDoItem>> GetItemsAsync()
        {
            return await Connection.Table<ToDoItem>().ToListAsync();
        }

        public async Task<int> DeleteItemAsync(ToDoItem item)
        {
            return await Connection.DeleteAsync(item);
        }

    }
}
