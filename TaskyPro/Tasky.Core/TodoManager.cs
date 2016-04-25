using System.Collections.Generic;
using System.Threading.Tasks;
using Tasky.Core.DAL;
using System;

namespace Tasky.Core
{
	public static class TodoManager
	{
        static TodoRepository DAL;
        static string dbLocation;

        public static void Initialize(string dabaseFilename)
        {
            if (dbLocation != null)
                throw new Exception("Cannot initialize TodoManager more than once.");

            dbLocation = dabaseFilename;
            DAL = new TodoRepository(dabaseFilename);
        }

		public static Task<TodoTask> GetTaskAsync(int id)
		{
            if (DAL == null)
                throw new Exception("Must call Initialize on TodoManager.");
            return DAL.GetTaskAsync(id);
		}
		
		public static Task<List<TodoTask>> GetTasksAsync()
		{
            if (DAL == null)
                throw new Exception("Must call Initialize on TodoManager.");
            return DAL.GetTasksAsync();
		}
		
		public static Task<int> SaveTaskAsync(TodoTask item)
		{
            if (DAL == null)
                throw new Exception("Must call Initialize on TodoManager.");
			return DAL.SaveTaskAsync(item);
		}
		
        public static Task<int> DeleteTaskAsync(TodoTask item)
		{
            if (DAL == null)
                throw new Exception("Must call Initialize on TodoManager.");
			return DAL.DeleteTask(item);
		}
	}
}