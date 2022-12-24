using LT.NET_project_cuoiki.dao;
using LT.NET_project_cuoiki.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LT.NET_project_cuoiki.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductDAO productDAO = new ProductDAO();
            List<ProductEntity> productList = new List<ProductEntity>();
            productList = productDAO.getAllProduct();

            return View(productList);
        }
     //  public ActionResult Search()
     //    {
     //       ProductDAO productDAO = new ProductDAO();
     //       List<ProductEntity> productSearch = new List<ProductEntity>();
      //      productSearch = productDAO.getProductByKey();
      //      return View(productSearch);
      //  }
        
        public void AddToCartMethod(int productId, int quantity)
        {
            Dictionary<string, CartItem> cartmap = Session["cartitem"] as Dictionary<string, CartItem>;
            ProductDAO productdao = new ProductDAO();
            ProductEntity product = productdao.getProductById(productId.ToString());
            CartItem p;
            if (cartmap == null)
            {
                cartmap = new Dictionary<string, CartItem>();
                p = new CartItem(product, quantity);
                cartmap.Add(productId.ToString(), p);
                Session["cartItem"] = cartmap;
            }
            else
            {
                if (cartmap.ContainsKey(productId.ToString()))
                {
                    p = cartmap[productId.ToString()];
                    p.incrementQuantity();
                    Session["cartItem"] = cartmap;
                }
                else
                {
                    p = new CartItem(product, quantity);
                    cartmap.Add(productId.ToString(), p);
                    Session["cartItem"] = cartmap;
                }
            }

            Session["cartItem"] = cartmap;
        }
        [HttpGet]
        public ActionResult AddToCart(int productId)
        {

            AddToCartMethod(productId, 1);
            return RedirectToAction("Index");
        }


    }
}