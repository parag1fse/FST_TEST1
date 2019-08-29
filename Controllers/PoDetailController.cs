using POSWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace POSWebApp.Controllers
{
    public class PoDetailController : Controller
    {
        // GET: PoDetail
        public ActionResult GetAllPoDetails()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/PoDetail/GetAllPoDetails");
                response.EnsureSuccessStatusCode();
                List<Models.PoDetail> PoDetails = response.Content.ReadAsAsync<List<Models.PoDetail>>().Result;
                ViewBag.Title = "All PoDetails";
                return View(PoDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditPoDetail(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/PoDetail/GetPoDetail?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PoDetail PoDetails = response.Content.ReadAsAsync<Models.PoDetail>().Result;
            ViewBag.Title = "All PoDetails";
            return View(PoDetails);
        }
        //[HttpPost]  
        public ActionResult Update(Models.PoDetail PoDetail)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/PoDetail/UpdatePoDetail", PoDetail);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllPoDetails");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/PoDetail/GetPoDetail?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PoDetail PoDetails = response.Content.ReadAsAsync<Models.PoDetail>().Result;
            ViewBag.Title = "All PoDetails";
            return View(PoDetails);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.PoDetail PoDetail)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/PoDetail/InsertPoDetail", PoDetail);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllPoDetails");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/PoDetail/DeletePoDetail?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllPoDetails");
        }
    }
}