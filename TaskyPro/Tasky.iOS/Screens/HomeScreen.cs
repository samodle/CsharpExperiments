using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using MonoTouch.Dialog;
using Foundation;
using Tasky.Core;

namespace Tasky
{
	public class HomeScreen : DialogViewController 
    {
        TaskDialog taskDialog;
        TodoTask currentTask;
        DialogViewController detailsScreen;
		List<TodoTask> tasks;
        BindingContext context;
		
		public HomeScreen () : base (UITableViewStyle.Plain, null)
		{
			Initialize ();
		}
		
		protected void Initialize()
		{
			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem (UIBarButtonSystemItem.Add), false);
			NavigationItem.RightBarButtonItem.Clicked += (sender, e) => ShowTaskDetails(new TodoTask());
		}

        protected void ShowTaskDetails (TodoTask task)
		{
			currentTask = task;
			taskDialog = new TaskDialog (task);
			
			var title = NSBundle.MainBundle.LocalizedString ("Task Details", "Task Details");
            context = new BindingContext(this, taskDialog, title);
			detailsScreen = new DialogViewController (context.Root, true);
			ActivateController(detailsScreen);
		}

		public async void SaveTask()
		{
			context.Fetch (); // re-populates with updated values
			currentTask.Name = taskDialog.Name;
			currentTask.Notes = taskDialog.Notes;
			currentTask.Done = taskDialog.Done;
			await TodoManager.SaveTaskAsync(currentTask);
			NavigationController.PopViewController (true);
		}

        public async void DeleteTask ()
		{
			if (currentTask.ID >= 0)
				await TodoManager.DeleteTaskAsync (currentTask);
			NavigationController.PopViewController (true);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			PopulateTable();			
		}
		
		protected async void PopulateTable ()
		{
			tasks = await TodoManager.GetTasksAsync();
			var newTaskDefaultName = NSBundle.MainBundle.LocalizedString ("<new task>", "<new task>");
			
            // make into a list of MT.D elements to display
            var le = tasks.Select(t =>
                new CheckboxElement((t.Name == "" ? newTaskDefaultName : t.Name), t.Done));

            // add to section
            var s = new Section();
			s.AddAll (le);
			
            // add as root
            Root = new RootElement ("Tasky") { s }; 
		}

		public override void Selected (NSIndexPath indexPath)
		{
			var task = tasks[indexPath.Row];
			ShowTaskDetails(task);
		}

		public override Source CreateSizingSource (bool unevenRows)
		{
			return new EditingSource (this);
		}

		public async void DeleteTaskRow(int rowId)
		{
			await TodoManager.DeleteTaskAsync(tasks[rowId]);
		}
	}
}