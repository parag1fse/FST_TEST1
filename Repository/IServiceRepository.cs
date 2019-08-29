using System.Net.Http;

namespace POSWebApp.Repository
{
    public interface IServiceRepository
    {
        HttpClient Client { get; set; }

        HttpResponseMessage DeleteResponse(string url);
        HttpResponseMessage GetResponse(string url);
        HttpResponseMessage PostResponse(string url, object model);
        HttpResponseMessage PutResponse(string url, object model);
    }
}