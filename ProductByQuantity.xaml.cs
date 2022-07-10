using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Library.ECommerceApp.Services;
using Xamarin.Forms;


namespace EcommerceAppMobile.Pages
{
    public  partial class ProductByQuantityPage : ContentPage
    {
        ObservableCollection<Product> products;
        Product prod;
        HomePage Home;
       
        public ProductByQuantityPage()
        {
            InitializeComponent();
           BindingContext = new ProductByQuantity();
        }
       

      

        private void Quantity_Changed(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1.0);

            QuantitySlider.Value = newStep * 1.0;
            Quantitynumber.Text = "Value: " + QuantitySlider.Value;

        }

        private async void Add_Clicked(Object sender, System.EventArgs e)
        {
            int num = 0;
            var P = new Product();
            var pq = P as ProductByQuantity;

            pq.Name= "Shirt";
            pq.Bogo = false;
            pq.Description = "White";
            pq.Quantity = 10;

            Home.Inventory.Add(P);
           
        }

        private async void Back_Clicked(Object sender, System.EventArgs e) { Navigation.PopModalAsync(); }

        private int productInInventory(Product prod)
        {
            int num = 0;
            foreach (Product item in Home.Inventory)
            {
                if (item.Name == prod.Name) { return num; }
                num += 1;
            }
            return -1;
        }

    }
}
public class ProductByQ
{
    public string name { get; set; }
    public int id { get; set; }
    public string description { get; set; }
    public double quantity { get; set; }
    public bool bogo { get; set; }
}
