using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TaskyUITests
{
    [TestFixture(Platform.Android)]
 //comment out platform you dont want to use ->   [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

 

        [Test]
        public void TaskyPro_CreatingATask_ShouldBeSuccessful()
        {
            AddANewTask("Get Milk", "Pick up some milk");
            app.WaitForElement(c => c.Marked("Get Milk"));
        }

        [Test]
        public void TaskyPro_DeletingATask_ShouldBeSuccessful()
        {
            AddANewTask("Test Delete", "This item should be deleted");

            app.Screenshot("task!");

            app.Tap("Test Delete");
            app.Tap("Delete");
            Assert.AreEqual(0, app.Query("Test Delete").Length);
        }

        [Ignore]
        public void AppLaunches()
        {
            app.Repl();
            // app.Screenshot("First screen.");
        }


        public void AddANewTask(string name, string description)
        {
            if (platform == Platform.iOS)
            {
                app.Tap(c => c.Button("Add"));
                app.EnterText(c => c.Class("UITextField").Index(0), name);
                app.EnterText(c => c.Class("UITextField").Index(1), description);
            }
            else
            {
                app.Tap("Add Task");
                app.EnterText(c => c.Class("EditText").Index(0), name);
                app.EnterText(c => c.Class("EditText").Index(1), description);
            }
            app.Tap("Save");
        }
    }
}

