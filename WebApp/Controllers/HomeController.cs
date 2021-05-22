using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Mqtt;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
