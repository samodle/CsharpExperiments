using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;
using System;

namespace Tasky.Core.DAL
{
    /// <summary>
    /// Database repository - replace with different implementation
    /// to use a different database type.
    /// </summary>
	class TodoRepository 
    {
        readonly SQLiteAsyncConnection db;
		
		public TodoRepository(string databaseFile)
		{
            if (string.IsNullOrEmpty(databaseFile))
                throw new ArgumentNullException("databaseFile");
            
            db = new SQLiteAsyncConnection(databaseFile);
            db.CreateTableAsync<TodoTask>().Wait();
		}
		
		public Task<TodoTask> GetTaskAsync(int id)
		{
            return db.Table<TodoTask>().Where(t => t.ID == id).FirstOrDefaultAsync();
		}
		
		public Task<List<TodoTask>> GetTasksAsync()
		{
            return db.Table<TodoTask>().ToListAsync();
		}
		
		public async Task<int> SaveTaskAsync (TodoTask item)
        {
            if (item.ID != 0)
            {
                await db.UpdateAsync(item);
                return item.ID;
            }
            return await db.InsertAsync(item);
        }

        public Task<int> DeleteTask(TodoTask item)
		{
            return db.DeleteAsync(item);
		}
	}
}

