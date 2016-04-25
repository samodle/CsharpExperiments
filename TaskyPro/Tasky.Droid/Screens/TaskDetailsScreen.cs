using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;
using Tasky.Core;

namespace Tasky.Droid.Screens 
{
	[Activity (Label = "Task Details")]			
	public class TaskDetailsScreen : Activity 
    {
		TodoTask task = new TodoTask();
		EditText notesTextEdit;
		EditText nameTextEdit;
		CheckBox doneCheckbox;
		
		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
			
			int taskID = Intent.GetIntExtra("TaskID", 0);
			if(taskID > 0) 
            {
				task = await TodoManager.GetTaskAsync(taskID);
			}
			
			// set our layout to be the home screen
			SetContentView(Resource.Layout.TaskDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			notesTextEdit = FindViewById<EditText>(Resource.Id.txtNotes);
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
			
            if (nameTextEdit != null)
			    nameTextEdit.Text = task.Name;
            if (notesTextEdit != null)
			    notesTextEdit.Text = task.Notes;
            if (doneCheckbox != null)
			    doneCheckbox.Checked = task.Done;
		}

		protected async void Save()
		{
			task.Name = nameTextEdit.Text;
			task.Notes = notesTextEdit.Text;
			task.Done = doneCheckbox.Checked;
			await TodoManager.SaveTaskAsync(task);
			
            Finish();
		}
		
		protected async void CancelDelete()
		{
			if(task.ID != 0) 
            {
				await TodoManager.DeleteTaskAsync(task);
			}
			
            Finish();
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_detailsscreen, menu);

            IMenuItem menuItem = menu.FindItem(Resource.Id.menu_delete_task);
            menuItem.SetTitle(task.ID == 0 ? "Cancel" : "Delete");

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_save_task:
                    Save();
                    return true;

                case Resource.Id.menu_delete_task:
                    CancelDelete();
                    return true;

                default: 
                    Finish();
                    return base.OnOptionsItemSelected(item);
            }
        }

	}
}