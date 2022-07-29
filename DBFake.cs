using System;
using System.Collections.ObjectModel;
using System.Linq;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{

    public static class DBFake
    {
        public static List<Product> cart = new List<Product>(){
        new Product
            {
                Name = "Shirt", Description = "Large", Price = 12.12, Quantity = 3, Bogo = false, TotalP = 33
            },
          new ProductByQuantity
            {
                Name = "Toothbrush", Description = "Greren", Price = 1.02, Quantity = 100, Bogo = true, TotalP = 1.02
            }};
      }

      
        public static List<Product> products = new List<Product>();
        
        
    }
