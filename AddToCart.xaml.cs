using System;
using System.Collections.ObjectModel;
using System.Linq;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{
    public partial class AddToCart : ContentPage
    {
        CartViewModel mycart = new CartViewModel();
        ObservableCollection<Product> products;
        HomePage home;


        public ObservableCollection<Product> Cart1 { get; set; }
        Product prod;

        public AddToCart(string Name, double Price, string Description, int Id, double amount, Product product, ObservableCollection<Product> p, HomePage myHome)
        {
            InitializeComponent();

            prodName.Text = "Product" + product.Name;
            prodPrice.Text = "Price Per: $" + product.Price;
            prodInventoryCount.Text = "Avalible: " + amount.ToString();
            prodDescription.Text = Description;
            prodAmountSliderCount.Text = "Units Added to Cart: 1";
            prodAmountSlider.Minimum = 1;
            prodAmountSlider.Maximum = amount;


            prod = product;
            products = p;
            home = myHome;
        }

        // edited amount using slider changed
        private async void Amount_Changed(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1.0);

            prodAmountSlider.Value = newStep * 1.0;
            prodAmountSliderCount.Text = "Units Added to Cart: " + prodAmountSlider.Value;
        }

        private async void Add_Clicked(Object sender, System.EventArgs e)
        {
            string str = prodAmountSliderCount.Text;
            var result = str.Substring(str.LastIndexOf(" ") + 1);

            var addProduct = new Product();

            if (prod is ProductByQuantity)
            {
                ProductByQuantity temp = prod as ProductByQuantity;
                ProductByQuantity addProd = new ProductByQuantity();//

                addProd.Price = temp.Price;
                addProd.Quantity = (int)prodAmountSlider.Value;
                addProd.Name = temp.Name;
                addProd.Description = temp.Description;
                addProd.Id = temp.Id;

                if (prod is ProductByQuantity)
                {
                    var pr = products.FirstOrDefault(p => p.Id == addProd.Id);
                    if (productInCart(addProd) != -1)
                    {
                        change((int)prodAmountSlider.Value);
                        Product temp1 = home.Cart[productInCart(addProd)];
                        (temp1 as ProductByQuantity).Quantity += ((int)prodAmountSlider.Value);
                        home.Cart[productInCart(addProd)] = temp1;
                    }
                    else
                    {
                        change((int)prodAmountSlider.Value);
                        home.Cart.Add(addProd);
                    }
                }
                else
                {
                    ProductByWeight t = prod as ProductByWeight;
                    var addP = new ProductByWeight();

                    addP.Price = t.Weight;
                    addP.Weight = (double)prodAmountSlider.Value;
                    addP.Name = t.Name;
                    addP.Description = t.Description;
                    addP.Id = temp.Id;



                    if (productInCart(addP) != -1)
                    {
                        change((int)prodAmountSlider.Value);
                        Product temp1 = home.Cart[productInCart(addP)];
                        (temp1 as ProductByQuantity).Quantity += ((int)prodAmountSlider.Value);
                        home.Cart[productInCart(addP)] = temp1;
                    }
                    else
                    {
                        change((int)prodAmountSlider.Value);
                        home.Cart.Add(addP);
                    }

                }

            }
        }

        private void Back_Clicked(Object sender, System.EventArgs e) { Navigation.PopModalAsync(); }

        private int productInCart(Product prod)
        {

            int count = 0;

            foreach (Product item in home.Cart)
            {
                if (item.Name == prod.Name) { return count; }
                count += 1;
            }

            return -1;

        }

        private bool change(int items)
        {
            if (prod is ProductByQuantity)
            {
                if ((prod as ProductByQuantity).Quantity - items < 0)
                {
                    if ((prod as ProductByQuantity).Quantity == 0)
                    {
                        prodAmountSlider.Minimum = 0;
                        home.Inventory.Remove(prod);
                        Navigation.PopModalAsync();
                        return true;
                    }
                    prodAmountSlider.Maximum = (prod as ProductByQuantity).Quantity;
                    return true;
                }
            }
            else
            {
                if ((prod as ProductByWeight).Weight - items < 0)
                {
                    prodAmountSlider.Maximum = (prod as ProductByWeight).Weight;
                    if ((prod as ProductByWeight).Weight == 0)
                    {
                        prodAmountSlider.Minimum = 0;
                        home.Inventory.Remove(prod);
                        Navigation.PopModalAsync();
                        return true;
                    }
                      return true;
                }
            }

            return false;
        }
    }
}

