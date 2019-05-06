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
    public partial class Edit : ContentPage
    {
        private Account _ac;

        public Edit()
        {
            InitializeComponent();
            Calc(uspassword);
        }

        private void Calc(View e)
        {
            e.HeightRequest = App.ScreenHeight / 16;
            e.Margin = new Thickness(App.ScreenWidth / 30, 0, App.ScreenWidth / 30, 0);
        }

        private void Src_SearchButtonPressed(object sender, EventArgs e)
        {
            string el1 = src.Text;
            if(el1 == App._a)
            {

                return;
            }
            if(DB.getAccountByName(el1) == null)
            {
                stk.IsVisible = false;
                return;
            }
            _ac = DB.getAccountByName(el1);
            stk.IsVisible = true;
             

        }

        //private void Kicka_button_Clicked(object sender, EventArgs e)
        //{
            
        //    //Fixa Logik
        //}

        private void Redigbtn_Clicked(object sender, EventArgs e)
        {
            string  el2 = uspassword.Text;
            
            if (el2 == null)
            {
                new Popup(new ErrorMessage("Var vänlig och fyll i fältet!"), this).Show();
                return;
            }
            _ac.Password = el2;
            DB.EditAccount(_ac);
            new Popup(new SuccessMessage("Lösenordet har Ändrats!"), this).Show();
            _ac = null;
            stk.IsVisible = false;
            
        }
    }
}