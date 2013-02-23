using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRApplication.Controllers
{
    public class PostingController : Controller
    {
        //
        // GET: /Posting/

        public ActionResult Index()
        {
            ViewBag.Title = "Managerial Accounting - Ninth Canadian Edition";
            ViewBag.Course = "AFM 102";
            ViewBag.Condition = "Good";
            ViewBag.PostedBy = "John Smith";
            ViewBag.Date = new DateTime(2013, 2, 21, 12, 0, 0);
            ViewBag.ISBN = "10 0-470-56479-2";
            ViewBag.price = 50.00;
            ViewBag.Author = "Walter T. Harrison";
            return View();
        }

        public ActionResult AddPosting()
        {
            return View();
        }
    }
}
