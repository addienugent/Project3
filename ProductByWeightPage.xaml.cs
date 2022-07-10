using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Library.ECommerceApp.Services;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class ProductByWeightPage : ContentPage
    {

        ObservableCollection<Product> products;
        Product prod;
        HomePage Home;

        public ProductByWeightPage()
        {
            InitializeComponent();
            BindingContext = new ProductByWeight();
        }


        private void Weight_Changed(object sender, ValueChangedEventArgs e)
        {
            var m = Math.Round(e.NewValue / 1.0);

            WeightSlider.Value = m * 1.0;

            Weightnumber.Text = "Pounds: : " + WeightSlider.Value;
        }

        private async void Add_Clicked(Object sender, System.EventArgs e)
        {
            string str = Weightnumber.Text;
            var result = str.Substring(str.LastIndexOf(" ") + 1);
            var prod = BindingContext;
           
           Home.Inventory.Add((Product)BindingContext);
            

        }

        private async void Back_Clicked(Object sender, System.EventArgs e) { Navigation.PopModalAsync(); }

        private int productInInventory(Product prod)
        {

            int count = 0;

            foreach (Product item in Home.Inventory)
            {
                if (item.Name == prod.Name) { return count; }
                count += 1;
            }

            return -1;

        }

    }
}


