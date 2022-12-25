using LT.NET_project_cuoiki.dao;
using LT.NET_project_cuoiki.Entity;
using LT.NET_project_cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;

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
        [HttpGet]
        public ActionResult Login()
        {
            UserModel check = (UserModel)Session["user"];
            if (check == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            UserModel check = (UserModel)Session["user"];
            if (check == null)
            {
                UserDAO user = new UserDAO();
                UserModel model = user.Login(username, password);
                if (model != null)
                {
                    Session["user"] = model;
                    return RedirectToAction("Index", "Home");
                } else
                {
                    ViewBag.Notify = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return View();

                }

            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return RedirectToAction("Login", "Shop");
        }
        [HttpPost]
        public ActionResult Register(string username, string email, string password)
        {
            UserDAO userDAO = new UserDAO();
            UserModel userModel = userDAO.checkUserExist(username);
            if (userModel != null)
            {
                ViewBag.NotifyRegister = "Tên tài khoản đã tồn tại";
                return View("Login");
            }
            else
            {
                userDAO.Register(username, email, password);
                userModel = userDAO.Login(username, password);
                Session["user"] = userModel;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult SignOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
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
        [HttpGet]
        public ActionResult ForgotPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPass(string username) 
        {
            UserDAO userDAO = new UserDAO();
            UserModel userModel = userDAO.checkUserExist(username);
            if (userModel == null)
            {
                ViewBag.Notify = "Tài khoản không tồn tại";
                return View();
            }
            else
            {
                Random r = new Random();
                int newPass = r.Next(100000,999999);
                userDAO.forgotPassword(username, newPass);
                userDAO.sendMaillForgotPassword(userModel.Email, newPass);
                ViewBag.Notify = "Mật khẩu mới đã được gửi về email của bạn";
                return View();
            }
            
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
