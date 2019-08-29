using POSWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace POSWebApp.Controllers
{
    public class SupplierController : Controller
    {
        IServiceRepository serviceObj;
        string type = "";

        public SupplierController()
        {
            serviceObj = new ServiceRepository();
        }
        public SupplierController(string test)
        {
            if (test == "TEST")
            {
                type = "test";
                serviceObj = new MockServiceRepository();
            }
            else
            {
                serviceObj = new ServiceRepository();

            }

        }
        // GET: Supplier
        public ActionResult GetAllSuppliers()
        {
            try
            {
                List<Models.Supplier> Suppliers = null;
                //ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/supplier/GetAllSuppliers");
                response.EnsureSuccessStatusCode();
                if (type != "test")
                {
                    Suppliers = response.Content.ReadAsAsync<List<Models.Supplier>>().Result;
                }

                ViewBag.Title = "All Suppliers";
                return View("GetAllSuppliers", Suppliers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditSupplier(string id)
        {
            Models.Supplier Suppliers = null;
            //ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Supplier/GetSupplier?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            if (type != "test")
            {
                Suppliers = response.Content.ReadAsAsync<Models.Supplier>().Result;
            }

            ViewBag.Title = "All Suppliers";
            return View("EditSupplier",Suppliers);
        }
        //[HttpPost]  
        public ActionResult Update(Models.Supplier Supplier)
        {
            //ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Supplier/UpdateSupplier", Supplier);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllSuppliers");
        }
        public ActionResult Details(string id)
        {
            Models.Supplier Suppliers = null;
            //ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Supplier/GetSupplier?id=" + id.ToString());
            response.EnsureSuccessStatusCode();

            if (type != "test")
            {
                 Suppliers = response.Content.ReadAsAsync<Models.Supplier>().Result;
            }
           
            ViewBag.Title = "All Suppliers";
            return View("Details",Suppliers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Supplier Supplier)
        {
           // ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Supplier/InsertSupplier", Supplier);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllSuppliers");
        }
        public ActionResult Delete(string id)
        {
           // ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Supplier/DeleteSupplier?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllSuppliers");
        }
    }
}