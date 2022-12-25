using LT.NET_project_cuoiki.DAO;
using LT.NET_project_cuoiki.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LT.NET_project_cuoiki.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tableDataTable(int id)
        {
            return View();
        }

        public ActionResult tableDataProduct()
        {
            return View();
        }

        public ActionResult formAddProduct(int id)
        {
            return View();
        }

        public ActionResult tableDataOrder(int id)
        {
            return View();
        }

        public ActionResult tableDataBanned(int id)
        {
            return View();
        }

        public ActionResult tableDataMoney(int id)
        {
            return View();
        }

        public ActionResult tableDataManager(int id)
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [ValidateInput(false)]
        public void AddProductByAdmin(int id, string title, string typeGem, int quantity,
            string category, string color, int price, string keyword, string designer, string ImageUpload, string mota)
        {


            if (id == 0 || title == null || typeGem == null || quantity == 0 || category == null || color == null ||
                price == 0 || keyword == null || designer == null || ImageUpload == null || mota == null)
            {
                Response.Redirect("AddProduct");
                //RedirectToAction("AddProduct");
            }
            else
            {
                new ProductAdminDAO().AddProduct(id, title, typeGem, quantity, category,
                color, price, keyword, designer, ImageUpload, mota);
                Response.Redirect("tableDataProduct");
            }

        }

        [HttpGet]
        public ActionResult DeleteProductByAdmin(int pid)
        {
            pid = Int32.Parse(Request["pid"]);
            new ProductAdminDAO().DeleteProduct(pid);
            return RedirectToAction("tableDataProduct");
        }

    }
}