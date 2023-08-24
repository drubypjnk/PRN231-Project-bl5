using BussinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Client.Controllers
{
    public class SkuController : Controller
    {
        private HttpClient client = null;
        private string ApiUrl = "";

        public SkuController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "http://localhost:5225/api/Sku";
        }

        public IActionResult Index()
        {
            return View("list");
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> DetailAsync(int id)
        {
            ViewBag.id=id;
            HttpResponseMessage response = await client.GetAsync(ApiUrl + $"/detail/{id}");
            string data = await response.Content.ReadAsStringAsync();
            SkuResDTO sku = JsonConvert.DeserializeObject<SkuResDTO>(data);
            return View(sku);
        }
    }
}
