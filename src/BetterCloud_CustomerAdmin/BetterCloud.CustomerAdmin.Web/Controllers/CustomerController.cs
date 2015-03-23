using System;
using System.Reflection;
using System.Web.Mvc;
using BetterCloud.CustomerAdmin.Web.Models;
using log4net;

namespace BetterCloud.CustomerAdmin.Web.Controllers
{
    public class CustomerController : Controller
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const string MethodLogFormat = "{0} Called"; 

        // GET: Customer
        public ActionResult Index()
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                var model = new CustomerModel();
                return View(model.GetCustomers());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(string customerId)
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                var model = new CustomerModel();

                return View(model.LoadCustomerById(customerId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                var model = new CustomerModel();
                return View(model.CreateInitCustomer());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));
                if (!ModelState.IsValid) return View();

                var model = new CustomerModel();
                model.CreateCustomer(collection);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string customerId)
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));
                var model = new CustomerModel();

                return View(model.LoadCustomerById(customerId)); ;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string customerId, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                var model = new CustomerModel();
                model.UpdateCustomer(customerId, collection);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string customerId)
        {
            try
            {
                var model = new CustomerModel();
                return View(model.LoadCustomerById(customerId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
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
            catch (Exception ex)
            {
                Log.Error(ex);
                return View("Error");
            }
        }
    }
}
