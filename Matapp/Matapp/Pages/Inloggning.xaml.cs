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
    public partial class Inloggning : ContentPage
    {
        public Inloggning()
        {
            InitializeComponent();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            
            string el1 = username.Text, el2 = password.Text;
            
            if (string.IsNullOrEmpty(el1) || string.IsNullOrEmpty(el2))
            {
                new Popup(new ErrorMessage("Fyll i alla fälten!"), this).Show();
                return;
            }
            else
            {
                for (int x = 0; x < DB.accounts.Count; x++)
                {
                    Account acc = DB.accounts[x];
                    if (acc.Username == el1 && acc.Password == el2)
                    {
                        if(acc.Username == App._a)
                        {
                            Navigation.PushAsync(new Admin());
                        } else
                        {
                            Navigation.PushAsync(new Restaurant());
                        }
                        return;
                    }
                }
                new Popup(new ErrorMessage("Du har angett fel uppgifter!"), this).Show();
            }
            
        }


    }
}