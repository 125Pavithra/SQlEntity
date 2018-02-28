using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SqlEntity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            ProjectDetailsEntities entities = new ProjectDetailsEntities();
            var projects = entities.ProjectTbls.ToList();
            return View();
            //return View(from project in entities.ProjectTbls
            //            select project);
            //var projects = customerService.GetAll().ToList();
            //var updatedCustomersList = new List<Customer>();

            //foreach (var item in customers)
            //{
            //    item.Address = "Bangalore";
            //    updatedCustomersList.Add(item);
            //    Console.WriteLine(item.CompanyName);
            //}

            //var result = customerService.UpdateCustomers(updatedCustomersList);
        }
    }
}