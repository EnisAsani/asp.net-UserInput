using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using neww.Models;

namespace neww.Controllers
    
{
    public class CustomerController : Controller
    {
        
        [HttpGet]
        public ActionResult AddorEdit()
        {
            Customer newCustomer = new Customer();

            return View(newCustomer);
        }
        [HttpPost]
        public ActionResult AddorEdit(Customer newCustomer)
        {
            using(DBModel dbmodel= new DBModel())
            {
                if (dbmodel.Customers.Any(x=> x.UserId == newCustomer.UserId))
                {
                    ViewBag.ErrorMessage = "Please enter another ID, that one is already taken.";
                    return View("AddorEdit", newCustomer);
                }
                dbmodel.Customers.Add(newCustomer);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Info Saved Successfully";
            return View("AddorEdit", new Customer());
        }
    }
}