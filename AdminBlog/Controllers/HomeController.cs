using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdminBlog.Models;

namespace AdminBlog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BlogContext _context;
    public HomeController(ILogger<HomeController> logger,BlogContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> AddCategory(Category category){
        await _context.AddAsync(category);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Category));
    }

    public IActionResult Category()
    {
        List<Category> list= _context.Category.ToList(); // burda listemizi yolluyoruz işte. herhangi bir filtereleme olmadan hepsini çeker böyle.
        return View(list);
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
