using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TL2_TP1.Models;
using WebApplication1.Models;
using static WebApplication1.Models.API;

namespace TL2_TP1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string problema1(float number)
        {
            try
            {
                return Math.Sqrt(number).ToString();
            }
            catch (Exception)
            {
                return "Los datos ingresados son incorrectos, debe ingresar numeros positivos.";
            }
        }

        public string problema2(float a, float b)
        {
            try
            {
                return (a / b).ToString();
            }
            catch (Exception)
            {
                return "Los datos ingresados son incorrectos, debe ingresar numeros.";
            }
        }

        public List<Provincia> problema3()
        {
            return API.GetApi();
        }

        public string problema4(float a, float b)
        {
            try
            {
                return (a / b).ToString();
            }
            catch (Exception)
            {
                return "Los datos ingresados son incorrectos, debe ingresar numeros.";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
