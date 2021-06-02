using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Mqtt;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public async Task<IActionResult> Index()
        {

            List<LedModel> ledList = new List<LedModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://ltnc-api.somee.com/api/tbled/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ledList = JsonConvert.DeserializeObject<List<LedModel>>(apiResponse);
                }
            }
            return View(ledList);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        [HttpPost]
        public IActionResult PublishMessage(string message)
        {
            try
            {
                return MqttService.PublishMessage(message)
                    ? (IActionResult)Ok()
                    : (IActionResult)BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IActionResult ReceiveMessage()
        {
            return Ok(MqttService.messageReceived.Message);
        }

        [HttpPut]
        public IActionResult setMessageDefault()
        {
            MqttService.messageReceived.Message = "";
            return MqttService.messageReceived.Message == "" ? (IActionResult)Ok()
                    : (IActionResult)BadRequest();
        }

        /*        public IActionResult Index()
                {
                    return View();
                }*/

        public async Task<IActionResult> History()
        {

            List<HistoryModel> historyList = new List<HistoryModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://ltnc-api.somee.com/api/tbhistory/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    historyList = JsonConvert.DeserializeObject<List<HistoryModel>>(apiResponse);
                }
            }
            return View(historyList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /*        public async Task<IActionResult> UpdateReservation(int id)
                {
                    LedModel reservation = new LedModel();
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync("http://localhost/ledapi/api/tblleds/" + id))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            reservation = JsonConvert.DeserializeObject<LedModel>(apiResponse);
                        }
                    }
                    return View(reservation);
                }*/

        [HttpPost]
        public async Task<IActionResult> UpdateLed(int id, string state)
        {
            LedModel led = new LedModel()
            {
                ID = id,
                isOn = state
            };
            JsonSerializerOptions serializerOptions;
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            HttpClient httpClient = new HttpClient();
            string base_url = "http://ltnc-api.somee.com/api/tbled/put";
            Uri uri = new Uri(string.Format(base_url, id));
            try
            {

                string json = System.Text.Json.JsonSerializer.Serialize<LedModel>(led, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await httpClient.PutAsync(uri, content);

            }
            catch (Exception ex)
            {
            }
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> CreateHistory(string _time, string _start, int _end, string _turn)
        {
            HistoryModel history = new HistoryModel()
            {
                time = _time,
                start = _start,
                end = _end,
                turn = _turn
            };
            JsonSerializerOptions serializerOptions;
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            HttpClient httpClient = new HttpClient();
            string base_url = "http://ltnc-api.somee.com/api/tbhistory/post";
            Uri uri = new Uri(string.Format(base_url, string.Empty));
            try
            {

                string json = System.Text.Json.JsonSerializer.Serialize<HistoryModel>(history, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await httpClient.PostAsync(uri, content);

            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
