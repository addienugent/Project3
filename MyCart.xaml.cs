using System;
using System.Collections.Generic;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class MyCart : ContentPage
    {

        HomePage home;

        public MyCart(HomePage myHome)
        {
            InitializeComponent();
            home = myHome;
            this.BindingContext = home;

        }

        private async void OnItemCartSelected(Object sender, ItemTappedEventArgs e)
        {

            if (e.Item is ProductByWeight)
            {
                var extra = e.Item as ProductByWeight;
                var details = e.Item as Product;

                await Navigation.PushModalAsync(new RemoveFromCart(home.Cart, extra, extra.Weight, home));
            }
            else if (e.Item is ProductByQuantity)
            {
                var extra = e.Item as ProductByQuantity;
                var details = e.Item as Product;

                await Navigation.PushModalAsync(new RemoveFromCart(home.Cart, extra, extra.Quantity, home));
            }

        }

    }
}

