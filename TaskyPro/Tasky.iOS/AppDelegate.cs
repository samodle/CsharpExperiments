using System;
using Foundation;
using UIKit;
using System.IO;
using Tasky.Core;

namespace Tasky 
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate 
    {
        public override UIWindow Window { get; set; }
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
            // Initialize the database path.
            const string sqliteFilename = "TaskDB.db3";
            string documents = NSFileManager.DefaultManager
                        .GetUrls(NSSearchPathDirectory.DocumentDirectory, 
                                    NSSearchPathDomain.User)[0].Path;
            string library = Path.Combine (documents, "..", "Library");
            var path = Path.Combine (library, sqliteFilename);
            TodoManager.Initialize(path);

            #if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
            #endif

            // Create the window
            Window = new UIWindow (UIScreen.MainScreen.Bounds);
            Window.RootViewController = new UINavigationController(new HomeScreen());
            Window.MakeKeyAndVisible();
			
			return true;
		}
	}
}