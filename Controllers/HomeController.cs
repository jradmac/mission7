using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

 
    [HttpGet]
    public IActionResult MovieInfo()
    {
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        var model = new MovieForm(); // Ensure you're passing a model if the view expects it
        return View("MovieInfo", model);
    }

    [HttpPost]
    public IActionResult MovieStuff(MovieForm m)
    {
        _context.Movies.Add(m);
        _context.SaveChanges();
            
        return View("Confirmation");
    }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult MovieList()
    {
        // linq
        var movies = _context.Movies;
        
        return View(movies); 
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {

        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View("MovieInfo", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(MovieForm updatedInfo)
    {
        _context.Attach(updatedInfo);
        _context.Entry(updatedInfo).State = EntityState.Modified;
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.SingleOrDefault(x => x.MovieId == id);

        if (recordToDelete == null)
        {
            return NotFound();
        }

        return View(recordToDelete);
    }
    
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var recordToDelete = _context.Movies.SingleOrDefault(x => x.MovieId == id);

        if (recordToDelete != null)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();
        }

        return RedirectToAction("MovieList");
    }


}