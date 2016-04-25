using System;
using Android.App;
using System.IO;
using Tasky.Core;
using Android.Runtime;

namespace Tasky.Droid
{
    [Application]
    public class App : Application
    {
        public App(IntPtr handle, JniHandleOwnership transfer)
            : base(handle,transfer)
        {
        }

        public override void OnCreate()
        {
            // Initialize the database name.
            const string sqliteFilename = "TaskDB.db3";
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine (libraryPath, sqliteFilename);
            TodoManager.Initialize(path);

            base.OnCreate();
        }
    }
}

