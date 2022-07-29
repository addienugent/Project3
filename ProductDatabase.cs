using System;
using System.Collections.ObjectModel;
using System.Linq;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
  public class ProductDatabase
  {
  
        public void Post(Product p)
        {
            var result = new Filebase().UpdateAdd(p, 1);
        }
     
        public List<Product> Get()
        {
            return new Filebase().Products;
        }
      
    }
    
 }
