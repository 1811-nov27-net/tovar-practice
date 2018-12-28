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

            return View();
        }

        // POST: Temp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemperatureRecord temps)
        { 
            try
            {
                var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(temps));

                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                if (ModelState.IsValid)
                {
                    using (var httpClient = new HttpClient())
                    {
                        // Do the actual request and await the response
                        var httpResponse = await httpClient.PostAsync("https://localhost:44338/api/temperature", httpContent);

                        // If the response contains content we want to read it!
                        if (httpResponse.Content != null)
                        {
                            var responseContent = await httpResponse.Content.ReadAsStringAsync();

                            // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                        }
                    }
                }
                return View(temps);
            }
            catch
            {
                return View();
            }
        }

        // GET: Temp/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Temp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection temps)
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(temps));

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            try
            {
              
                var updated = httpContent.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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