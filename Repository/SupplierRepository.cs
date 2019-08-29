using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace POSWebApp.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public HttpClient Client { get; set; }
        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }

    public class MockServiceRepository : IServiceRepository
    {
        public HttpClient Client { get; set; }
        public MockServiceRepository()
        {
            Client = new HttpClient();
            //Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            //HttpResponseMessage msg = new HttpResponseMessage();
           


            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("[{'SUPLNO':'1','SUPLNAME':'1','SUPLADDR':'1'}]"),
            };
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("[{'SUPLNO':'1','SUPLNAME':'1','SUPLADDR':'1'}]"),
            };
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
             return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("[{'status':'true'}]"),
            };
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("[{'SUPLNO':'1','SUPLNAME':'1','SUPLADDR':'1'}]"),
            };
        }
    }
}