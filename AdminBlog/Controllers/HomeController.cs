using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdminBlog.Models;
using Microsoft.Identity.Client;

namespace AdminBlog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BlogContext _context;
    public HomeController(ILogger<HomeController> logger, BlogContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> AddCategory(Category category)
    { //update metodunu ayrı yazmaya gerek yok
        if (category.Id == 0)
        {
            await _context.AddAsync(category);
        }
        else
        {
            _context.Update(category);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Category));
    }
    public async Task<IActionResult> CategoryDetails(int Id)
    {
        var category = await _context.Category.FindAsync(Id);
        if (category == null)
        {
            return NotFound(); // Eğer category null ise hata döndür
        }
        return Json(category);
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
        List<Category> list = _context.Category.ToList(); // burda listemizi yolluyoruz işte. herhangi bir filtereleme olmadan hepsini çeker böyle.
        return View(list);
    }










    public IActionResult Author()
    {
        List<Author> list = _context.Author.ToList(); // burda listemizi yolluyoruz işte. herhangi bir filtereleme olmadan hepsini çeker böyle.
        return View(list);
    }

    public async Task<IActionResult> AddAuthor(Author author)
    { //update metodunu ayrı yazmaya gerek yok
        if (author.Id == 0)
        {
            await _context.AddAsync(author);
        }
        else
        {
            _context.Update(author);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Author));
    }
    public async Task<IActionResult> AuthorDetails(int Id)
    {
        var author = await _context.Author.FindAsync(Id);
        if (author == null)
        {
            return NotFound(); // Eğer category null ise hata döndür
        }
        return Json(author);
    }
    public async Task<IActionResult> DeleteAuthor(int? Id)
    {
        if (Id == null)
        {
            return NotFound(); // Eğer Id null ise, hata sayfası döndür
        }
        var author = await _context.Author.FindAsync(Id);
        if (author == null)
        {
            return NotFound(); // Eğer bu Id'ye sahip bir yazar yoksa, hata sayfası döndür
        }
        _context.Author.Remove(author); // yazar sil
        await _context.SaveChangesAsync();   // Değişiklikleri veritabanına kaydet

        return RedirectToAction(nameof(Author)); // Silme işleminden sonra Author sayfasına yönlendir
    }




    public IActionResult Login(string Email,String Password){
        var author = _context.Author.FirstOrDefault(w=> w.Email == Email && w.Password == Password );
        if(author== null){
            return RedirectToAction(nameof(Index));
        }
        else{
            HttpContext.Session.SetInt32("id",author.Id); 
        }
         return RedirectToAction(nameof(Index));
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
