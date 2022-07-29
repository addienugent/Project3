using System;
using System.Collections.ObjectModel;
using System.Linq;
using EcommerceAppMobile.ViewModels;
using Library.ECommerceApp;
using Library.ECommerceApp.Models;
using Xamarin.Forms;

namespace EcommerceAppMobile.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<ItemControllers> _logger;




        public CartController(ILogger<ItemControllers> logger)
        {
            _logger = logger;
        }


  
        
        [HttpGet("Delete/{p}")]
      
        public void Delete(string p)
        {
            new Filebase().Delete(prod, 2);

        }
      
        [HttpPost]
      
        public Product UpdateAddCart(Product p, int pid)
        {

            var pchanged = new Filebase().cart.FirstOrDefault(p => p.Name == prod.Name);
            if (pchanged == null)
            {
                var result = new Filebase().UpdateAdd(p,  2);
                return p;
            }
            else{
                int index = new Filebase().cart.IndexOf(itemToUpdate);
                
                if(prod is ProductByQuantity)
                {
                     var holder =  (prod as ProductByQuantity)
                     holder.Quantity; = holder.Quantity + (pchanged as ProductByQuantity).Quantity;
                     
                    holder.GetTotalP();
                   
                }
                else 
                {
                     var holder =  (prod as ProductByWeight);
                     holder.Weight = holder.Weight + (pchanged as ProductByWeight).Weight;
                     
                    holder.GetTotalP();
                }

                var result = new Filebase().UpdateAdd(prod, 2);
                return p;
            }

        }

      
      [HttpGet]
        public List<Product> Get()
        {
            return new CartDatabase().Get();

        }    
      
    }
