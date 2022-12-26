using LT.NET_project_cuoiki.dao;
using LT.NET_project_cuoiki.DAO;
using LT.NET_project_cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LT.NET_project_cuoiki.Controllers
{
    public class ShopController : Controller
    {
        ConnectionMysql connection = new ConnectionMysql();
        // GET: Shop
        [HttpGet]
        public ActionResult Product(string id)
        {

            //load product
            ProductDAO productDAO = new ProductDAO();
            List<ProductEntity> productList;
            if (id != null)
            {

                productList = productDAO.getProductByCate(Int32.Parse(id));
            }
            else
            {
                productList = productDAO.getAllProduct();
            }


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
                }
                else
                {
                    ViewBag.Notify = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return View();

                }

            }
            else
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
                int newPass = r.Next(100000, 999999);
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
        public ActionResult AddToCartDetail(int productId, int quantity)
        {
            AddToCartMethod(productId, 1);
            return RedirectToAction("Details/" + productId);
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
        [HttpGet]
        public ActionResult buyNow(int id)
        {
            AddToCartMethod(id, 1);
            return RedirectToAction("Checkout");
        }

        [HttpGet]
        public ActionResult CheckoutControl(string name, string hnum, string ward, string county, string province, string mail, string phone, string note)
        {

            if (name == "" || hnum == "" || ward == "" || county == "" || province == "" || phone == "")
            {
                return RedirectToAction("Checkout");
            }
            else
            {
                CheckoutDAO checkoutDAO = new CheckoutDAO();
                Dictionary<string, CartItem> map = Session["cartItem"] as Dictionary<string, CartItem>;
                if (map != null)
                {
                    if (Session["user"] == null)
                    {
                        checkoutDAO.addCheckout(name, hnum, ward, county, province, mail, phone, note, map, null);
                    }
                    else
                    {
                        UserModel userModel = (UserModel)Session["user"];

                        checkoutDAO.addCheckout(name, hnum, ward, county, province, mail, phone, note, map, userModel.Id.ToString());
                    }
                }
                else
                {
                    return RedirectToAction("Product");
                }
                Session["cartItem"] = null;

                return Content("<a href=\"/Shop/Product\" style=\"margin:auto\">GO BACK</a>" +
                    "<script language='javascript' type='text/javascript'>alert('Đặt hàng thành công!');</script>");
            }

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
