using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class EditProductW : ContentPage
    {
        public EditProductW(ProductByWeight p)
        {

            InitializeComponent();
        }

        public EditProductW(string name, double price, string description, int id, double weight, ProductByWeight extra, ObservableCollection<Product> cart, ProductPage productPage)
        {
        }
        private void Back_Clicked(Object sender, System.EventArgs e) { Navigation.PopModalAsync(); }
    }
}
