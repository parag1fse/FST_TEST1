using POSWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace POSWebApp.Controllers
{
    public class PoMasterController : Controller
    {
        // GET: PoMaster
        public ActionResult GetAllPoMasters()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/PoMaster/GetAllPO");
                response.EnsureSuccessStatusCode();
                List<Models.PoMaster> PoMasters = response.Content.ReadAsAsync<List<Models.PoMaster>>().Result;
                ViewBag.Title = "All PoMasters";
                return View(PoMasters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditPoMaster(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/PoMaster/GetPoMaster?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PoMaster PoMasters = response.Content.ReadAsAsync<Models.PoMaster>().Result;
            ViewBag.Title = "All PoMasters";
            return View(PoMasters);
        }
        //[HttpPost]  
        public ActionResult Update(Models.PoMaster PoMaster)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/PoMaster/UpdatePoMaster", PoMaster);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllPoMasters");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/PoMaster/GetPoMaster?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PoMaster PoMasters = response.Content.ReadAsAsync<Models.PoMaster>().Result;
            ViewBag.Title = "All PoMasters";
            return View(PoMasters);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.PoMaster PoMaster)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/PoMaster/InsertPoMaster", PoMaster);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllPoMasters");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/PoMaster/DeletePoMaster?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllPoMasters");
        }
    }
}