using System;
using System.Collections.Generic;
using Library.ECommerceApp;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class Checkout : ContentPage
    {
        HomePage home;
        private double totalPrice = 0;
        public Checkout(HomePage newhome)
        {
            InitializeComponent();
            home = newhome;
            this.BindingContext = home;

            foreach (Product prod in newhome.Cart)
            {
                totalPrice += prod.TotalP;
            }

            total.Text = String.Format("Total:", (totalPrice).ToString());
            tax.Text = String.Format("Total: ", (totalPrice * 0.07).ToString());
            totalTax.Text = String.Format("Total: ", (totalPrice * 1.07).ToString());
        }
    } }
