using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Matapp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : CarouselPage
    {
        public IntroPage()
        {
           

            InitializeComponent();
            //Show the image in the app throught the name in app.xaml.cs!*
            logo.Source = App.getImage("TLogo");
            _User.Source = App.getImage("User");
            _Admin.Source = App.getImage("Admin");


            //Creating TapGestureRecognizers
            var UserImage = new TapGestureRecognizer();
             UserImage.Tapped += UserImage_Tapped;
            _User.GestureRecognizers.Add(UserImage);


            var AdminImage = new TapGestureRecognizer();
            AdminImage.Tapped += AdminImage_Tapped;
            _Admin.GestureRecognizers.Add(AdminImage);


        }

        private void AdminImage_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Inloggning());
        }

        private void UserImage_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Info", "Det är en användare", "avbryt");
        }


        

        private void Button_Clicked(object sender, EventArgs e)
        {
            CurrentPage = this.Children[1];
        }

        

         
    }
}