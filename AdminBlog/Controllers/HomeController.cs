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

    public async Task<IActionResult> DeleteCategory(int? Id)
{
    if (Id == null)
    {
        return NotFound(); // Eğer Id null ise, hata sayfası döndür
    }

    var category = await _context.Category.FindAsync(Id);

    if (category == null)
    {
        return NotFound(); // Eğer bu Id'ye sahip bir kategori yoksa, hata sayfası döndür
    }

    _context.Category.Remove(category); // Kategoriyi sil
    await _context.SaveChangesAsync();   // Değişiklikleri veritabanına kaydet

    return RedirectToAction(nameof(Category)); // Silme işleminden sonra Category sayfasına yönlendir
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
