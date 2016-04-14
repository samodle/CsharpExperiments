using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Graphics.Drawables;
using System.IO;


namespace XamarinUniversitry
{
    public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer 
    {
        List<Instructor> instructors;
        Java.Lang.Object[] sectionHeaders;
        Dictionary<int, int> positionForSectionMap;
        Dictionary<int, int> sectionForPositionMap;

        public InstructorAdapter (List<Instructor> instructors)
        {
            this.instructors = instructors;

            sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(instructors);
            positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(instructors);
            sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(instructors);

        }

        //we need to override some stuff to make this work

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }

        public int GetPositionForSection(int section)
        {
            return positionForSectionMap[section];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPositionMap[position];
        }
        // public Java.Lang.Object.


        public override Instructor this[int position]
        {
            get
            {
                return instructors[position];
            }
        }
        public override int Count
        {
            get
            {
                return instructors.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = convertView;// inflater.Inflate(Resource.Layout.InstructorRow, parent, false);
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.InstructorRow, parent, false);


                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

                view.Tag = new ViewHolder() { Photo = photo, Name = name, Specialty = specialty };
            }
            var holder = (ViewHolder) view.Tag;

            Stream stream = parent.Context.Assets.Open(instructors[position].ImageUrl);
          //  Drawable drawable = Drawable.CreateFromStream(stream, null);
            holder.Photo.SetImageDrawable(ImageAssetManager.Get(parent.Context,instructors[position].ImageUrl));

            holder.Name.Text = instructors[position].Name;
            holder.Specialty.Text = instructors[position].Specialty;

            return view;
        }

    }

}