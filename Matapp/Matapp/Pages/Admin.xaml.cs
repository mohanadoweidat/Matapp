using Matapp.MenuItems;
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
    public partial class Admin : MasterDetailPage
    {
        public List<MasterPageItems> menuList { get; set; }
        public Admin()
        {
            InitializeComponent();
            masterbg.Source = App.getImage("_logga");
            menuList = new List<MasterPageItems>();
             // Adding menu items to menuList and you can define title ,page and icon
            menuList.Add(new MasterPageItems() { Title = "Lägga till restaurant", Icon = "plus.png", TargetType = typeof(Add)});
            menuList.Add(new MasterPageItems() { Title = "Redigera Konton", Icon = "edit.png", TargetType = typeof(Edit) });


            // Setting our list to be ItemSource for ListView in RectorPage.xaml
            NavigationList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Pages.Add)));
            
        }

        private void NavigationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItems)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}