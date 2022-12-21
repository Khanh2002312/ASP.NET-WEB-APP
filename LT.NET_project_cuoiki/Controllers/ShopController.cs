using LT.NET_project_cuoiki.dao;
using LT.NET_project_cuoiki.Entity;
using LT.NET_project_cuoiki.Models;
using System.Collections.Generic;

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

            AddToCart();
            return View();


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

        [HttpGet]
        public void AddToCart()
        {
            string id = Session["inputId"] as string;

            Dictionary<string, ProductInCart> cartMap = Session["cartItem"] as Dictionary<string, ProductInCart>;
            ProductDAO productDAO = new ProductDAO();
            ProductEntity product = productDAO.getProductById(id);
            ProductInCart p;
            if (cartMap == null)
            {
                cartMap = new Dictionary<string, ProductInCart>();
                p = new ProductInCart(product, 1);
                cartMap.Add(id, p);
            }
            else
            {
                if (cartMap.ContainsKey(id))
                {
                    p = cartMap[id];
                    p.incrementQuantity();
                }
                else
                {
                    p = new ProductInCart(product, 1);
                    cartMap.Add(id, p);
                }
            }
            Session["test"] = id + 1;
            Session["cartItem"] = cartMap;

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
