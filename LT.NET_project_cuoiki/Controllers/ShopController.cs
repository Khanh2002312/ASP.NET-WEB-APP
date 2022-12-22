using LT.NET_project_cuoiki.dao;
using LT.NET_project_cuoiki.Entity;
using LT.NET_project_cuoiki.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace LT.NET_project_cuoiki.Controllers
{
    public class ShopController : Controller
    {

        ConnectionMysql connection = new ConnectionMysql();
        // GET: Shop
        public ActionResult Product()
        {

            //load product
            ProductDAO productDAO = new ProductDAO();
            List<ProductEntity> productList = new List<ProductEntity>();
            productList = productDAO.getAllProduct();

            return View(productList);
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            ProductDAO productDAO = new ProductDAO();
            ProductEntity product = new ProductEntity();
            product = productDAO.getProductById(id.ToString());
            string cateName = productDAO.getCategoryName(id.ToString());
            string gemName = productDAO.getGem(id.ToString());
            List<ProductEntity> listProduct = productDAO.getAllProduct();
            DetailModel detailModel = new DetailModel(product, cateName, gemName, listProduct);

            return View(detailModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Cart()
        {
            var cart = Session["cartItem"];
            var map = new Dictionary<string, CartItem>();
            if (cart != null)
            {
                map = (Dictionary<string, CartItem>)cart;
            }
            return View(map);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ForgotPass()
        {
            return View();
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }
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
            return RedirectToAction("Product");
        }
        [HttpGet]
        public ActionResult AddToCartDetail(int productId,int quantity)
        {
            AddToCartMethod(productId, 1);
            return RedirectToAction("Details");
        }
        [HttpGet]
        public ActionResult DeleteAllItem()
        {
            Session["cartItem"] = null;

            return RedirectToAction("Cart");
        }
        [HttpGet]
        public ActionResult DeleteItem(string productId)
        {
            Dictionary<string, CartItem> cartMap = (Dictionary<string, CartItem>)Session["cartItem"];
            cartMap.Remove(productId);
            Session["cartItem"] = cartMap;

            return RedirectToAction("Cart");
        }
        [HttpGet]
        public ActionResult IncrementQuantity(string productId)
        {
            Dictionary<string, CartItem> cartMap = (Dictionary<string, CartItem>)Session["cartItem"];
            int num = cartMap[productId].Quantity;
            num++;
            cartMap[productId].Quantity = num;
            Session["cartItem"] = cartMap;
            return RedirectToAction("Cart");
        }
        [HttpGet]
        public ActionResult DecrementQuantity(string productId)
        {
            Dictionary<string, CartItem> cartMap = (Dictionary<string, CartItem>)Session["cartItem"];
            int num = cartMap[productId].Quantity;
            num--;
            cartMap[productId].Quantity = num;
            Session["cartItem"] = cartMap;
            return RedirectToAction("Cart");
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
