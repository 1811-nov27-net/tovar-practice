using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemperatureWebStore.Models;

namespace TemperatureWebStore.Controllers
{
 

    public class TempController : Controller
    {
     //   private List<TemperatureRecord> temperatures { get; set; }

        public HttpClient Client { get; set; }

        public TempController(HttpClient client) {
            Client = client;
        }
        // GET: Temp
        public async Task<IActionResult> Index()
        {
            // send "GET api/temperature" to service, get headers of reponse
            var response = await Client.GetAsync("https://localhost:44338/api/temperature");

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }
            var responseBody = await response.Content.ReadAsStringAsync();

            //this is a string, so it must be deserilized into a C# object.

            List<TemperatureRecord> temperatures= JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody);

            return View(temperatures);
           // return View();
        }

        // GET: Temp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Temp/Create
        public ActionResult Create()
        {

            return View(new TemperatureRecord { Time = DateTime.Now });
        }
        public static HttpContent ToContent<T>(T obj)
        {
            // instead of this we can use PostAsJsonAsync, easier
            string json = JsonConvert.SerializeObject(obj);
            // declare the encoding (unicode)
            // and the "media type" (JSON) of the thing to send in the request body
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }
        // POST: Temp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemperatureRecord temps)
        {
            try
            {
                // set unit to 1 (celsius)
                temps.Unit = 1;
                // use POST method, not GET, based on the route the service has defined
                HttpResponseMessage response = await Client.PostAsync("https://localhost:44338/api/temperature", ToContent(temps));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(temps);
            }
            catch
            {
                return View(temps);
            }
        }

        // GET: Temp/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var json = await Client.GetStringAsync($"https://localhost:44338/api/temperature/{id}");
            return View(JsonConvert.DeserializeObject<TemperatureRecord>(json));
        }

        // POST: Temp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TemperatureRecord temps)
        {
            try
            {
                temps.Unit = 1;

                var url = $"https://localhost:44338/api/temperature/{id}";
                var reponse = await Client.PutAsJsonAsync(url, temps);

                if(reponse.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(temps);
            }
            catch
            {
                return View(temps);
            }
        }

        // GET: Temp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Temp/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}