using System;

using Xamarin.Forms;

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;

namespace EcommerceAppMobile
{
    public class ReadFile
    {
        public ReadFile()
        {
        }

        public void write()
        {
            List<Product> toSerialize = new List<Product>();
            List<Product> toSerialize1 = new List<Product>();

            Console.WriteLine("Creating");

            var Hat = new ProductByQuantity(1.00, 10, "Hat", "Straw", 1);
            var Fries = new ProductByQuantity(2.00, 20, "Shirt", "White", 2);
            var Rice = new ProductByQuantity(2.00, 35, "Rice", "Fried", 3);
            var apple = new ProductByQuantity(5.00, 25, "Apple", "Canned & Packaged Foods", 4);
            var plates = new ProductByQuantity(3.50, 100, "Plates", "Paper", 5);
            
           
            toSerialize.Add(Hat);
            toSerialize.Add(Fries);
            toSerialize.Add(Rice);
            toSerialize.Add(apple);
            toSerialize.Add(plates);


            var sushi = new ProductByWeight(10.50, 100, "Sushi", "Refrigerated Foods", 11);
            var donuts = new ProductByWeight(5.50, 150, "Donuts", "Glazed", 12);
            var Cups = new ProductByWeight(4.25, 100, "Cups", "Plasticc", 13);
            var Beef = new ProductByWeight(15.75, 200, "Meat", "Red", 14);

            toSerialize1.Add(sushi);
            toSerialize1.Add(donuts);
            toSerialize1.Add(Cups);
            toSerialize1.Add(Beef); 
            
            String inser = JsonConvert.SerializeObject(toSerialize);
            String insera = JsonConvert.SerializeObject(toSerialize1);

          
            string fq = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sByQuantity.txt");
            string fw = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sByWeight.txt");

            File.WriteAllText(fq, inser);
            File.WriteAllText(fw, insera);

        }

        public List<ProductByQuantity> readQ()
        {
            List<ProductByQuantity> Inventory = new List<ProductByQuantity>();

            string fileNameByQuantity = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sByQuantity.txt");

            if (File.Exists(fileNameByQuantity))
            {
                Inventory = JsonConvert.DeserializeObject<List<ProductByQuantity>>(File.ReadAllText(fileNameByQuantity));

                foreach (Product prod in Inventory)
                    Console.WriteLine(prod.Name);
                return Inventory;
            }
     
            return Inventory;
        }

        public List<ProductByWeight> readW()
        {
            List<ProductByWeight> Inventory = new List<ProductByWeight>();


            string fileW = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serializedByWeight.txt");

            if (File.Exists(fileW))
            {
                Inventory = JsonConvert.DeserializeObject<List<ProductByWeight>>(File.ReadAllText(fileW));

                foreach (Product x in Inventory)
                    Console.WriteLine(x.Name);
                return Inventory;
            }
            return Inventory;
        }
    }
}
