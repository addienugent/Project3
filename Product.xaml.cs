using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Library.ECommerceApp.Services;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class ProductPage : ContentPage
    {
        public ObservableCollection<Product> ProductInventory { get; set; }
        public ObservableCollection<Product> Cart { get; set; }


        public ProductPage()
        {
            InitializeComponent();

            ProductInventory = new ObservableCollection<Product>();
            Cart = new ObservableCollection<Product>();

            BindingContext = new ProductViewModel(ProductInventory);

        


        }


        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {

            if (e.Item is ProductByWeight)
            {
                var pr = e.Item as ProductByWeight;
                var pw = e.Item as Product;

                await Navigation.PushModalAsync(new EditProductW(pw.Name, pw.Price, pw.Description, pw.Id, pr.Weight, pr, Cart, this));
            }
            else if (e.Item is ProductByQuantity)
            {
                var pe = e.Item as ProductByQuantity;
                var pq = e.Item as Product;

                await Navigation.PushModalAsync(new EditProductQ(pq.Name, pq.Price, pq.Description, pq.Id, pe.Quantity, pe, Cart, this));
            }

        }

    }
}

    
