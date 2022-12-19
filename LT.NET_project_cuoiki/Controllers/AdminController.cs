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

        public ActionResult tableDataProduct(int id)
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
    }
}