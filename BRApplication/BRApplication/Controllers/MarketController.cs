using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BRApplication.Models; 

namespace BRApplication.Controllers
{
    public class MarketController : Controller
    {
        //
        // GET: /Market/

        public ActionResult Index()
        {
            List<MarketPostModel> mpmLst = new List<MarketPostModel>();
            MarketPostModel mpm1 = new MarketPostModel(false, "AFM 101", "Excellent", "Asma Patel", DateTime.Now, "978-3-16-148410-0", "Mark Twain", 300);
            MarketPostModel mpm2 = new MarketPostModel(false, "MATH 135", "Good", "Johnny Depp", DateTime.Now, "978-3-16-148410-0", "John Jacob JingleHeimer", 150.99);
            MarketPostModel mpm3 = new MarketPostModel(false, "STAT 230", "Good", "Jack Johnson", DateTime.Now, "978-3-16-148410-0", "Kiets d a", 0.99);
            MarketPostModel mpm4 = new MarketPostModel(false, "ACTS 230", "Good", "Hugh Grant", DateTime.Now, "978-3-16-148410-0", "Homer J. Simpson", 500.99);
            
            mpmLst.Add(mpm1);
            mpmLst.Add(mpm2);
            mpmLst.Add(mpm3);
            mpmLst.Add(mpm4);

            return View(mpmLst); 
        }

    }
}
