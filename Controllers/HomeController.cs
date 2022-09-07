using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppkaPracownicy.Models;

namespace AppkaPracownicy.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //DATEPREP HERE
        DateTime today = DateTime.Today;
        
        ViewData["Today"] = DateTime.Today.Day;
        ViewData["FirstDay"] = ((int)new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).DayOfWeek + 6) % 7;
        ViewData["PrevMonthNumOfDays"] = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month-1);
        ViewData["ThisMonthNumOfDays"] = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
        //zrobic ilepustych kwatratow
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
