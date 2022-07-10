using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class EditProductQ : ContentPage
    {
        private ProductByQuantity pq;

        public EditProductQ()
        {
            InitializeComponent();
        }

        public EditProductQ(string name, ProductByQuantity pq)
        {
            this.pq = pq;
        }

        public EditProductQ(string name, double price, string description, int id, int quantity, ProductByQuantity extra, ObservableCollection<Product> cart, ProductPage productPage)
        {
        }
    }
}

