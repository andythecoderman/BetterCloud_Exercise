using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BetterCloud.CustomerAdmin.Web.Models;

namespace BetterCloud.CustomerAdmin.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerModel model = new CustomerModel();
            return View(model.GetCustomers());
        }

        // GET: Customer/Details/5
        public ActionResult Details(string customerId)
        {
            var model = new CustomerModel();

            return View(model.LoadCustomerById(customerId));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var model = new CustomerModel();
                model.CreateCustomer(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string customerId)
        {
            var model = new CustomerModel();

            return View(model.LoadCustomerById(customerId));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string customerId, FormCollection collection)
        {
            try
            {
                var model = new CustomerModel();
                model.UpdateCustomer(customerId, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string customerId)
        {
            var model = new CustomerModel();

            return View(model.LoadCustomerById(customerId));
           
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(string customerId, FormCollection collection)
        {
            try
            {
                var model = new CustomerModel();
                model.DeleteCustomer(customerId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
