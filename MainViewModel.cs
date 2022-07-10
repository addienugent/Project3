using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using EcommerceAppMobile.Pages;
using Library.ECommerceApp.Services;
using Xamarin.Forms.Xaml;


namespace EcommerceAppMobile.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged 
    {
        public string Query { get; set; }
        private ProductServices productService;

        public ProductViewModel SelectedProduct { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            
            productService = ProductServices.Current;
            //BindingContext = new ProductViewModel();
        }
        public ProductViewModel selectedProduct
        {
            get
            {
                return SelectedProduct;
            }

            set
            {
                SelectedProduct = value;
                NotifyPropertyChanged();
            }
        }}}
