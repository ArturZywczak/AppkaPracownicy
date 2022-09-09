using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppkaPracownicy.Models;
using System.Globalization;
using System.Xml.Linq;

namespace AppkaPracownicy.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int id) {
        int year, month;



        if (id != 0) {
            month = id / 10000;
            year = id % 10000;
        }
        else {
            month = DateTime.Today.Month;
            year = DateTime.Today.Year;
        }

        //DATEPREP HERE
        DateTime thisDate = new DateTime(year, month, 1);
        ViewData["PrevDate"] = Int32.Parse(thisDate.AddMonths(-1).ToString("MMyyyy"));
        ViewData["NextDate"] = Int32.Parse(thisDate.AddMonths(1).ToString("MMyyyy"));


        ViewData["Today"] = DateTime.Today.Day + id;
        ViewData["FirstDay"] = ((int)new DateTime(year, month, 1).DayOfWeek + 6) % 7;
        ViewData["PrevMonthNumOfDays"] = DateTime.DaysInMonth(year, month==1? 12 : month - 1);
        ViewData["ThisMonthNumOfDays"] = DateTime.DaysInMonth(year, month);
        ViewData["ThisMonthAndYear"] = thisDate.ToString("MMMM", new CultureInfo("pl-PL")) + " " + year.ToString();
        
        return View();
    }

    public IActionResult Settings()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
