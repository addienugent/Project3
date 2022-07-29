using System;
using System.Collections.ObjectModel;
using System.Linq;
using EcommerceAppMobile.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
  public class Filebase
    {
        private string _root;
        private string _cartRoot;
        private string _productsRoot;
        
        private Filebase _instance;


        public Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        public Filebase()
        {
            _root = "C:\\temp";
            _cartRoot = $"{_root}\\cart";
            _productsRoot = $"{_root}\\products";
        }

        public Product UpdateAdd(Product p, int pid)
        {
            string pr;
            if (pid == 1)
            {
                pr = $"{_productRoot}/{p.Id}.json";
            } 
            else if(pid == 2)
            {
                pr = $"{_cartRoot}/{p.Id}.json";
            }
            else
            {
                pr = "error";
            }
          
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            
            File.WriteAllText(path, JsonConvert.SerializeObject(prod));
            return prod;
        }

        public List<Product> products
        {
            get
            {
              var p = new List<Products>(); 
              
                var rProds = new DirectoryInfo(_productsRoot);
                
                foreach(var p in root.GetFiles())
                {
                    _products.Add(JsonConvert.DeserializeObject<Product>(File.ReadAllText(productsFile.Id));
                }
                return _products;
            }
        }

        public List<Product> cart
        {
            get
            {
                var root = new DirectoryInfo(_cartRoot);
                
                var _cart = new List<Product>();
                
                foreach (var cartFile in root.GetFiles())
                {
                    _cart.Add(JsonConvert.DeserializeObject<Product>(File.ReadAllText(cartFile.Id));
                }
                return _cart;
            }
        }



        public bool Delete(string p, int pid)
        {
            
            string path;
            if (pid == 1)
            {
                path = $"{_productsRoot}/{p}.json";
            }
            else if (pid == 2)
            {
                path = $"{_cartRoot}/{p}.json";
            }
            else
            {
                path = "error";
            }


            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }
    }
}
