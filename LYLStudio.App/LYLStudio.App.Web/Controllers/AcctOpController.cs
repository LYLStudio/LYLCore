using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYLStudio.App.Web.Models;

namespace LYLStudio.App.Web.Controllers
{
    public class AcctOpController : Controller
    {
        // GET: AcctOp
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(BasicInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }



            return RedirectToAction(nameof(Index));
        }
    }
}