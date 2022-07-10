using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class InventoryMainPage : ContentPage
    {
        
        HomePage myHome;
        public ObservableCollection<Product> Inventory { get; set; }
        public ObservableCollection<Product> Cart { get; set; }

        public InventoryMainPage()
        {
            InitializeComponent();
            Inventory = new ObservableCollection<Product>();
            Cart = new ObservableCollection<Product>();
            BindingContext = new ProductViewModel(Inventory);
        }
         
        private async void Edit_clicked(Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductPage());
        }

        private async void AddQ_clicked(Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductByQuantityPage());
        }


        private async void AddW_clicked(Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductByWeightPage());
        }

       

        private async void Save_clicked(Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SavePage());
        }

        private async void Load_clicked(Object sender, System.EventArgs e)
        {
            
            await Navigation.PushModalAsync(new LoadPage());
        }


    }
}
