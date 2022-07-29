using System;
using System.Collections.ObjectModel;
using System.Linq;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Pages
{

  [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        

        public ProductController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }
    
      
        [HttpGet("Delete/{p}")]
        public void Delete(string p)
        {
            new Filebase().Delete(p, 1);

        }

        [HttpGet]
        public List<Product> Get()
        {
            return new ProductDatabase().Get();

        }

        [HttpPost]
        public Product UpdateAddProduct(Product p)
        {
            var result = new Filebase().UpdateAdd(p, 1);

            return p;

            
        }


    }
