using System;
using ToDo.App.Data;
using ToDo.App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App
{
    public partial class App : Application
    {
        public static DatabaseContext Context { get; set; }

        public App()
        {
            InitializeComponent();
            InitalizeDatabase();
            MainPage = new NavigationPage(new HomePage());
        }

        private void InitalizeDatabase()
        {
            string folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbPath = System.IO.Path.Combine(folderApp, "ToDo.db3");
            Context = new DatabaseContext(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
