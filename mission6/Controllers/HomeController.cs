using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6.Models;

namespace mission6.Controllers;

public class HomeController : Controller
{
    private readonly MovieContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(MovieContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View("GetToKnowJoel");
    }

    public IActionResult MovieInfo()
    {
        return View("MovieInfo");
    }

    [HttpGet]
    public IActionResult MovieStuff()
    {
        return View("MovieInfo");
    }

    [HttpPost]
    public IActionResult MovieStuff(MovieForm m)
    {
        _context.MovieForm.Add(m);
        _context.SaveChanges();
            
        return View("Confirmation");
    }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}