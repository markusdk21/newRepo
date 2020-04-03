using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace HomeDepotWebApp.Controllers
{
    public class HomeController : Controller
    {
        private HomeDepotContext db = new HomeDepotContext();
        private static Rent rent;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer req)
        {
            var customer = db.Customers.Where(c => c.Username.Equals(req.Username) && c.Password.Equals(req.Password)).FirstOrDefault();

            if(customer != null) {
                rent = new Rent { Customer = db.Customers.Find(customer.CustomerId)};                
                      
                return RedirectToAction("Overview");
            } else {
                return RedirectToAction("Index");
            }
        }

        
        public ActionResult Overview()
        {
            List<Tool> tools = db.Tools.ToList<Tool>();
            
            return View(tools);
        }

        public ActionResult Book(int id)
        {

            rent.RentTool = db.Tools.Find(id);

            return View("Book", rent);
        }

        [HttpPost]
        public ActionResult BookConfirm(int days, string PickUp)
        {
            rent.Days = days; 
            rent.PickUp = PickUp;
            rent.Status = Status.Reserveret;
            db.Customers.Attach(rent.Customer);
            db.Tools.Attach(rent.RentTool);
            db.Rents.Add(rent);
            db.SaveChanges();
            return View(rent);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}