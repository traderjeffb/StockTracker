using Microsoft.AspNet.Identity;
using StockTracker.Models;
using StockTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockMarketTracker.Controllers
{
    [Authorize]
    public class TradeController : Controller
    {
        // GET: Trade
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TradeService(userId);
            var model = service.GetTrades();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TradeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTradeService();

            if (service.CreateTrade(model))
            {
               TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

                ModelState.AddModelError("", "Note could not be created.");
                return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTradeService();
            var model = svc.GetTradeById(id);

            return View(model);
        }

        private TradeService CreateTradeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TradeService(userId);
            return service;
        }
    }
}