using Matapp.Pages;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Matapp
{
    public partial class App : Application
    {
        public static Dictionary<string, ImageSource> images = new Dictionary<string, ImageSource>();
        public static Dictionary<string, string> strings = new Dictionary<string, string>();
        private const string PATH = "Matapp";
        public static int ScreenWidth;
        public static int ScreenHeight;
        public static string _a = "Admin";

        public App()
        {
            InitializeComponent();
             
            Loada();
        }

        private async void Loada()
        {
           
            images.Add("_logga", loadImage("Logga.jpg"));
            images.Add("User", loadImage("male.png"));
            images.Add("Admin", loadImage("project.png"));
            images.Add("TLogo", loadImage("Logo-00000.png"));
            MainPage = new NavigationPage(new IntroPage());

            await DB.LoadAccounts();

        }


        public static ImageSource getImage(string key)
        {

            return images.ContainsKey(key) ? images[key] : loadImage("no-image.png");
        }

        public static ImageSource loadImage(string path)
        {
            return ImageSource.FromResource(PATH + ".images." + path,
             Assembly.GetExecutingAssembly());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
         
    }
}
