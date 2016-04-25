using SQLite;

namespace Tasky.Core
{
	/// <summary>
	/// Represents a Task.
	/// </summary>
	public class TodoTask
	{
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
	}
}

