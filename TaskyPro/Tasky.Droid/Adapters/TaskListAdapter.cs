using System.Collections.Generic;
using Android.Widget;
using Android.App;
using Android.Views;
using Tasky.Core;

namespace Tasky.Droid.Adapters 
{
	public class TaskListAdapter : BaseAdapter<TodoTask> {
		readonly Activity context;
		readonly IList<TodoTask> tasks;
		
		public TaskListAdapter (Activity context, IList<TodoTask> tasks)
		{
			this.context = context;
			this.tasks = tasks;
		}
		
		public override TodoTask this[int index]
		{
			get { return tasks[index]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return tasks.Count; }
		}
		
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = tasks[position];			
            View view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.TaskListItem, null);

            var nameLabel = view.FindViewById<TextView>(Resource.Id.lblName);
            nameLabel.Text = item.Name;
            var notesLabel = view.FindViewById<TextView>(Resource.Id.lblDescription);
            notesLabel.Text = item.Notes;
            var checkMark = view.FindViewById<ImageView>(Resource.Id.checkMark);
            checkMark.Visibility = item.Done ? ViewStates.Visible : ViewStates.Gone;

			return view;
		}
	}
}