using Matapp.Database;
using NTI_QRsystem.Components;
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
    public partial class Add : ContentPage
    {
        public Add()
        {
            InitializeComponent();
            Calc(usnm); Calc(uspassword);
        }

        private async void Add_retaurants_Clicked(object sender, EventArgs e)
        {
            string el1 = usnm.Text, el2 = uspassword.Text;
            //Fixa Pop up och databas logik
            if (string.IsNullOrEmpty(el1) || string.IsNullOrEmpty(el2))
            {
                new Popup(new ErrorMessage("Fyll i alla fälten!"), this).Show();
            }
            else
            {
                if(DB.getAccountByName(el1) != null)
                {
                    new Popup(new ErrorMessage("Kontot finns redan!"), this).Show();
                    return;
                }
                Account a = new Account() { Username = el1, Password = el2 };
                await DB.AddAccount(a);
                new Popup(new SuccessMessage("Kontot har Lagts till "), this).Show();
            }
        }


        private void Calc(View e)
        {
            e.HeightRequest = App.ScreenHeight / 16;
            e.Margin = new Thickness(App.ScreenWidth / 30, 0, App.ScreenWidth / 30, 0);
        }
    }
}