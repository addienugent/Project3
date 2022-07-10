using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;

namespace EcommerceAppMobile.ViewModels
{
    public class CartViewModel
    {
        public List<Product> myCart = new List<Product>();


        public ObservableCollection<Product> Cart { get; set; }



        public CartViewModel()
        {
            Cart = new ObservableCollection<Product>();

            foreach (Product prod in myCart)
            {
                if (prod is ProductByQuantity)
                {
                    if (((ProductByQuantity)prod).Quantity > 0)
                    {
                        Cart.Add(prod);
                    }
                }
                else if (prod is ProductByWeight)
                {
                    if (((ProductByWeight)prod).Weight > 0)
                    {
                        Cart.Add(prod);
                    }
                }
            }

            addtolist();
        }
        public void addtolist()
        {
            
        }

    }
}

