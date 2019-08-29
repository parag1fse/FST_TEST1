using POSWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace POSWebApp.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult GetAllItems()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Item/GetAllItems");
                response.EnsureSuccessStatusCode();
                List<Models.Item> Items = response.Content.ReadAsAsync<List<Models.Item>>().Result;
                ViewBag.Title = "All Items";
                return View(Items);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditItem(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Item/GetItem?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Item Items = response.Content.ReadAsAsync<Models.Item>().Result;
            ViewBag.Title = "All Items";
            return View(Items);
        }
        //[HttpPost]  
        public ActionResult Update(Models.Item Item)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Item/UpdateItem", Item);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllItems");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Item/GetItem?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Item Items = response.Content.ReadAsAsync<Models.Item>().Result;
            ViewBag.Title = "All Items";
            return View(Items);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Item Item)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Item/InsertItem", Item);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllItems");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Item/DeleteItem?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllItems");
        }
    }
}