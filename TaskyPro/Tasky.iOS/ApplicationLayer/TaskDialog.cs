using UIKit;
using MonoTouch.Dialog;
using Tasky.Core;

namespace Tasky 
{
	/// <summary>
	/// Wrapper class for Task, to use with MonoTouch.Dialog. If it was just iOS platform
	/// we could apply these attributes directly to the Task class, but because we share that
	/// with other platforms this wrapper provides a bridge to MonoTouch.Dialog.
	/// </summary>
	public class TaskDialog 
    {
		public TaskDialog (TodoTask task)
		{
			Name = task.Name;
			Notes = task.Notes;
			Done = task.Done;
		}
		
		[Entry("task name")]
		public string Name { get; set; }

		[Entry("other task info")]
		public string Notes { get; set; }
		
		[Entry("Done")]
		public bool Done { get; set; }

		[Section ("")]
		[OnTap ("SaveTask")]
		[Alignment (UITextAlignment.Center)]
    	public string Save;
		
		[Section ("")]
		[OnTap ("DeleteTask")]
		[Alignment (UITextAlignment.Center)]
    	public string Delete;
	}
}