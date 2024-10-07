**ASP.NET Core MVC projesi**, Microsoft’un sunduğu bir framework olan ASP.NET Core ile web uygulamaları geliştirmek için kullanılan bir modeldir. MVC (Model-View-Controller) mimarisi, yazılımda modülerlik ve kodun daha düzenli olmasını sağlamak amacıyla kullanılır. Bu mimari, uygulamanın işleyişini 3 temel katmana ayırır:

1. Model (M)
Görev: Uygulamanın veri ve iş mantığını temsil eder. Veritabanıyla etkileşime giren kodlar genellikle modelde bulunur.
Örnek: Bir kullanıcının bilgilerini saklayan bir User modeli.
2. View (V)
Görev: Kullanıcıya gösterilecek olan HTML veya diğer UI bileşenlerini oluşturur. View, modelden gelen verileri kullanıcıya anlamlı bir şekilde sunar.
Örnek: Kullanıcı bilgilerini bir form içinde gösteren bir HTML sayfası.
3. Controller (C)
Görev: Kullanıcıdan gelen istekleri işler, gerekli veriyi modelden alır ve bu veriyi view’a yönlendirir. Controller, uygulamanın iş mantığını yönetir.
Örnek: Bir kullanıcının giriş bilgilerini kontrol eden ve doğruluğunu model üzerinden sorgulayan bir LoginController.

Proje Yapısı
- Controllers klasörü: Uygulamadaki iş mantığını yöneten kontrolör sınıfları burada bulunur.
- Models klasörü: Veritabanı ile ilgili işlevler ve veri yapıları buraya yerleştirilir.
- Views klasörü: HTML, Razor gibi kullanıcıya gösterilecek bileşenler burada yer alır.
- wwwroot klasörü: Statik dosyalar (CSS, JavaScript, resimler) burada bulunur.
- appsettings.json: Uygulamanın yapılandırma ayarlarını içerir (örneğin, veritabanı bağlantı dizgileri).

ASP.NET Core MVC projelerinde, her bir dosyanın belli bir işlevi vardır. Sana bu dosyaların ne işe yaradığını, nasıl çalıştıklarını basit bir şekilde açıklayacağım.

1. Home klasörü altındaki dosyalar:
- Index.cshtml
Bu, HomeController adlı kontrolcünün Index adlı aksiyon metodu ile ilişkilidir. 
Bu dosya, kullanıcının web sitesine girdiğinde gördüğü ana sayfanın HTML ve Razor (ASP.NET'in sunucu tarafı şablonlama dili) kodlarını içerir.
Özetle: Anasayfanın görünümü burada düzenlenir. Kullanıcının gördüğü yazılar, düğmeler, resimler gibi şeyler buradan yönetilir.
Privacy.cshtml
Bu da HomeController adlı kontrolcünün Privacy adlı aksiyon metodu ile ilişkilidir.
Genelde gizlilik politikası gibi sayfalar için kullanılır. Web sitesinde "Gizlilik Politikası" bağlantısına tıklandığında bu dosya çalışır.
Özetle: Gizlilik politikasıyla ilgili bilgileri buradan düzenlersin.
2. Shared klasörü altındaki dosyalar:
- _Layout.cshtml
Bu dosya, web sitesinin ana şablon dosyasıdır. Tüm sayfalar bu şablonu kullanır.
Örneğin, web sitende her sayfanın başında aynı menü (header) ve altında aynı footer olmasını istiyorsun. Bunları Layout.cshtml içinde tanımlarsın.
Sayfaların ortasındaki içerikler, @RenderBody() ifadesiyle bu dosyanın içerisine yerleştirilir.
Özetle: Web sitesinin ortak yapısını oluşturur. Menü, footer, site başlığı gibi her sayfada aynı olan bileşenler buraya eklenir.
- _ViewStart.cshtml
Bu dosya, her bir sayfa yüklenmeden önce çalışır.
Genellikle burada, sayfaların hangi layout dosyasını (genelde Layout.cshtml) kullanması gerektiği belirtilir. Örneğin, @{ Layout = "_Layout"; } yazarız.
Bu sayede her sayfa otomatik olarak Layout.cshtml şablonunu kullanır.
Özetle: Her sayfa açıldığında varsayılan olarak hangi layout'u kullanacağını belirtir.
- _ValidationScriptsPartial.cshtml
Bu dosya, form doğrulaması (validation) için gerekli olan JavaScript dosyalarını yükler.
Örneğin, kullanıcı bir formda adını yazmazsa veya yanlış veri girerse, JavaScript ile kullanıcıyı uyarırsın. İşte bu uyarı işlemlerinin arka planında çalışan script'ler burada bulunur.
Özetle: Formların doğrulama işlemleriyle ilgili JavaScript dosyalarını yükler.
- Error.cshtml
Bu dosya, hatalı bir sayfa yüklendiğinde gösterilir.
Mesela, kullanıcı olmayan bir sayfaya giderse (404 hatası) veya sunucu tarafında bir hata oluşursa bu dosya çalışır ve kullanıcıya hata mesajı gösterir.
Özetle: Web sitesinde bir hata olduğunda kullanıcıya gösterilecek hata sayfasıdır.
- _ViewImports.cshtml
_ViewImports.cshtml, ASP.NET Core MVC projelerinde, tüm view dosyalarına (cshtml dosyalarına) ortak olarak eklenen direktifleri (using gibi) tanımlamak için kullanılır.
Bu dosya, projendeki her view dosyası için bazı kütüphaneleri, yardımcı metodları ve TagHelper'ları (HTML tag'leriyle çalışan özel C# sınıfları) otomatik olarak ekler.
Projede sıkça kullanılan namespace'leri burada tanımlayabilirsin. Böylece her sayfada tekrar tekrar @using yazmana gerek kalmaz.
Bu direktifle ASP.NET Core MVC'deki TagHelper'ları kullanabilirsin. TagHelper'lar, HTML etiketlerine özellikler ekleyerek Razor syntax'ı ve C# kodunu daha temiz yazmanı sağlar. @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
cshtml dosyalarıyla ilişkilendirilen model sınıflarını burada tanımlayabilirsin. Her view dosyası için tek tek model sınıfı tanımlamak yerine, burada bir defa tanımlayıp tüm view'larda kullanabilirsin. @model ile.
3. Bu dosyalar nasıl çalışır?
Controller (Kontrolcü) Nedir?
Web sitenin kontrolcüsü (Controller), hangi sayfaya (view) gitmesi gerektiğini belirleyen kısımdır.
Mesela, bir kullanıcı https://localhost/Home/Index adresine giderse, HomeController içindeki Index() metodu çalışır ve Index.cshtml dosyası kullanılarak sayfa oluşturulur.
Yani kontrolcü, sayfalar arasında bir yönlendirici gibidir. Hangi sayfa açılacak, hangi veri gönderilecek, bunları kontrolcü karar verir.
* View Nedir? 
cshtml dosyaları, view yani görünümlerdir. Bunlar, kullanıcının tarayıcısında görünen HTML sayfalarıdır. Ancak ASP.NET'in sağladığı Razor ile hem HTML hem de sunucu tarafı C# kodlarını yazabilirsin.
Örneğin: Index.cshtml dosyasının içinde hem HTML hem de C# kodları bir arada çalışabilir.
* Layout Nedir?
Layout, tüm sayfalar için ortak bir iskelet yapısıdır. Her sayfa aynı menüye ve aynı footera sahip olsun diye layout kullanırız.
@RenderBody() komutu, her sayfanın kendi içeriğinin buraya yerleştirilmesini sağlar.
Örnek: Basit bir senaryo
Kullanıcı https://localhost/Home/Index adresine girdi.
HomeController çalıştı ve Index() metodunu çağırdı.
Index.cshtml dosyası kullanılarak sayfa oluşturulmaya başlandı.
Bu sırada sayfa, Layout.cshtml dosyasını kullanarak bir şablon (header, footer) aldı.
Kullanıcının gördüğü sayfa, Layout.cshtml şablonuna göre düzenlenmiş ve Index.cshtml'deki içerikle dolmuş oldu.
* Özet:
Index.cshtml ve Privacy.cshtml: Belirli sayfalara ait görünümler (HTML benzeri dosyalar).
_Layout.cshtml: Tüm sayfalar için ortak olan yapı (örneğin menü ve footer).
_ViewStart.cshtml: Sayfalar açılmadan önce hangi layout'un kullanılacağını belirler.
_ValidationScriptsPartial.cshtml: Form doğrulama script'lerini yükler.
Error.cshtml: Hata sayfası.
_ViewImports.cshtml, projendeki tüm view dosyalarına ortak olan using direktiflerini ve TagHelper'ları tanımlar.
Bu sayede her sayfada ekstra tanımlama yapmana gerek kalmadan belirlediğin namespace'ler ve TagHelper'lar tüm view'larda otomatik olarak geçerli olur.
Bu dosya, kodu düzenli ve temiz tutmanı sağlar, her seferinde tekrar tekrar aynı kodları yazmaktan kurtarır.




**Entity Framework (EF)**, Microsoft tarafından geliştirilen bir Object-Relational Mapping (ORM) kütüphanesidir. EF, .NET uygulamaları ile veritabanları arasında bir köprü görevi görerek, geliştiricilerin veritabanı ile etkileşimde bulunmalarını kolaylaştırır. İşte Entity Framework'ün bazı temel işlevleri ve faydaları:

1. Veritabanı İşlemlerini Kolaylaştırma
EF, veritabanı işlemlerini C# nesneleri ile gerçekleştirmeyi sağlar. Bu, SQL sorguları yazmadan veritabanındaki verilere erişim, güncelleme ve silme işlemleri yapmanıza olanak tanır.

2. Nesne Modelleri Oluşturma
EF, veritabanındaki tabloları nesne modellerine (class) dönüştürerek, bu nesnelerle çalışmanızı sağlar. Böylece veritabanı yapısı ile kod yapısı arasında bir eşleme (mapping) oluşturur.

3. LINQ Desteği
EF, LINQ (Language Integrated Query) desteği ile birlikte gelir. Bu, SQL benzeri sorguları C# dilinde yazmanıza olanak tanır. LINQ, daha okunabilir ve yazımı kolay sorgular oluşturmanıza yardımcı olur.

4. Veritabanı Geçmişi Yönetimi
EF, veritabanı değişikliklerini takip ederek, modelinize göre veritabanını otomatik olarak güncelleyebilir. Migration özelliği sayesinde veritabanı şemasındaki değişiklikleri yönetmek oldukça kolaydır.

5. Verimlilik ve Performans
EF, optimize edilmiş sorgular oluşturur ve veritabanı ile olan etkileşimleri en iyi şekilde yönetir. Bunun sonucunda, uygulamanızın performansı artabilir.

6. Destek ve Geliştirme Kolaylığı
Entity Framework, .NET ekosisteminin bir parçası olduğundan, büyük bir topluluğa ve güçlü belgelere sahiptir. Bu sayede sorunlarınızı çözmek daha kolaydır ve yeni özellikler eklemek daha hızlı gerçekleşir.

7. Farklı Veritabanı Sistemleri ile Uyumlu
EF, çeşitli veritabanı yönetim sistemleriyle (SQL Server, PostgreSQL, MySQL, SQLite, vb.) çalışabilir. Bu, farklı projelerde farklı veritabanlarını kullanmanızı kolaylaştırır.

Örnek Kullanım:

using (var context = new MyDbContext())
{
    // Yeni bir kullanıcı ekleme
    var user = new User { Name = "John Doe", Email = "john@example.com" };
    context.Users.Add(user);
    context.SaveChanges(); // Değişiklikleri veritabanına kaydet

    // Kullanıcıları sorgulama
    var users = context.Users.ToList();
}


Sonuç:
 Entity Framework, geliştiricilere veritabanı işlemlerini daha kolay ve verimli bir şekilde yapma imkanı sunar. ORM teknolojileri sayesinde, uygulama geliştirme sürecini hızlandırır ve kodun okunabilirliğini artırır. Bu nedenle, .NET uygulamalarında sıklıkla tercih edilen bir kütüphanedir.


 ------------------------------------------
 Veri Tabanı:

 
 ![alt text](<Ekran görüntüsü 2024-10-03 223504.png>)




 Veri tabanıına bağlanma işlemleri:
 appsettings.json dosyasına kendi veritabanımızı ekledik 
"ConnectionStrings": {
    "BlogDb": "Server=DESKTOP-0QE53DC;Database=BlogDb;Trusted_Connection=True;Encrypt=False"
  },
program.cs dosyasına 
var connectionString = builder.Configuration.GetConnectionString("BlogDb");
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connectionString));
daha sonra terminalde 
>dotnet ef migrations add first
>dotnet ef database update
kodlarını çalıştırdık.( Çalışmazlarsa önce -> dotnet tool install --global dotnet-ef)
Böylece veri tabanımız ve modellere göre tablolarımız oluşturulumuş oldu.

İndirilen Paketler:(bu komutlar ile)
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design 



Controller Detayları:

**using System.Diagnostics;** <br>
**using Microsoft.AspNetCore.Mvc;** <br> 
**using AdminBlog.Models;** <br>

using System.Diagnostics;: Bu kütüphane, sistemle ilgili tanılama işlemleri için kullanılır. Örneğin, hata ayıklama veya günlüğe kaydetme işlemleri için faydalıdır.  
using Microsoft.AspNetCore.Mvc;: Bu kütüphane ASP.NET Core'da MVC yapısının (Model-View-Controller) temel sınıflarını sağlar. Burada Controller sınıfını kullanmak için bu kütüphane dahil ediliyor.  
using AdminBlog.Models;: Bu da AdminBlog projesindeki modellerin bulunduğu namespace. Bu kısımda BlogContext ve Category gibi modelleri kullanmak için gerekli.  

**namespace AdminBlog.Controllers;**  

Bu kod, AdminBlog.Controllers adında bir namespace (isim alanı) oluşturur. Bu, projedeki sınıfları düzenlemek için kullanılır ve aynı zamanda bu kontrolörün proje içindeki diğer parçalardan ayırt edilmesini sağlar.  

**public class HomeController : Controller**  

public class HomeController : Controller: HomeController adında bir sınıf oluşturur ve bu sınıf, ASP.NET Core'un Controller sınıfından türetilmiştir. Controller sınıfı, MVC modelinde kullanılan temel sınıftır ve HTTP isteklerini işlemede yardımcı olur.

**private readonly ILogger<HomeController> _logger;  
private readonly BlogContext _context;**  

private readonly ILogger<HomeController> _logger;: Bu satır, ILogger türünde bir logger nesnesi tanımlar. Logger, uygulamada hataları veya diğer bilgileri kaydetmek için kullanılır. HomeController tipi, hangi kontrolör için logger kullanıldığını belirler.
private readonly BlogContext _context;: Bu satır ise, veritabanı işlemleri yapmak için kullanılan BlogContext nesnesini tanımlar. Bu, Entity Framework ile çalışan ve veritabanına erişim sağlayan bir sınıf.

**public HomeController(ILogger<HomeController> logger, BlogContext context)
{
    _logger = logger;
    _context = context;
}**

public HomeController(ILogger<HomeController> logger, BlogContext context): Bu, HomeController sınıfının yapıcı metodudur. Kontrolör sınıfı ilk oluşturulduğunda çalıştırılır. Logger ve BlogContext nesneleri, yapıcı metodun parametreleri olarak alınır.
_logger = logger; ve _context = context;: Parametre olarak gelen logger ve context nesnelerini sınıf içindeki private alanlara atar, böylece bu nesneler diğer metodlar tarafından kullanılabilir hale gelir.

**public async Task<IActionResult> AddCategory(Category category)
{
    await _context.AddAsync(category);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Category));
}**

public async Task<IActionResult> AddCategory(Category category): Bu, bir kategori eklemek için kullanılan asenkron bir metottur. Category adında bir model nesnesi parametre olarak alınır.    
async Task<IActionResult>: Bu, metodun asenkron olduğunu belirtir. Asenkron metotlar, uzun süren işlemleri engellemeden yapılmasını sağlar.  
await _context.AddAsync(category);: Bu satır, veritabanına yeni bir kategori ekler. await ifadesi, bu işlemin asenkron yapılmasını sağlar.  
await _context.SaveChangesAsync();: Bu satır ise, yapılan değişiklikleri veritabanına kaydeder. Yine asenkron olarak çalışır.  
return RedirectToAction(nameof(Category));: Bu satır, kategori ekleme işlemi tamamlandıktan sonra Category adlı aksiyona (sayfaya) yönlendirme yapar.  

**public IActionResult Category()
    {
        List<Category> list= _context.Category.ToList(); 
        return View(list);
    }**

1. public IActionResult Category()
Bu, bir action metodudur ve IActionResult türünde bir sonuç döndürür. IActionResult, bir action metodunun farklı türde sonuçlar döndürebileceğini belirtir. Örneğin, bir sayfa (View), JSON verisi ya da bir yönlendirme döndürebilir.

2. List<Category> list = _context.Category.ToList();
Bu satırda:

_context.Category: BlogContext isimli veritabanı bağlamı (context) aracılığıyla Category tablosuna erişiyoruz. Bu tablo veritabanındaki tüm kategori verilerini içerir.

.ToList(): Bu metod, Category tablosundaki tüm verileri çeker ve bir List<Category> (kategori listesi) olarak döndürür. Yani, veritabanındaki tüm kategori kayıtlarını liste halinde alıyoruz.

Bu adımda herhangi bir filtreleme uygulanmaz, tüm kategoriler listelenir.

3. return View(list);
View(list): Bu satır, list adındaki List<Category> nesnesini View'e (yani kullanıcıya gösterilecek HTML sayfasına) gönderir. Bu, veritabanından çekilen tüm kategorileri kullanıcıya gösterecek View'de (örneğin Category.cshtml dosyasında) kullanılabilir hale getirir.

**public IActionResult Index()
{
    return View();
}**

public IActionResult Index(): Bu, ana sayfa (index) için bir aksiyon metodudur. Uygulamanın ana sayfasını döndürmek için kullanılır. View() metodu, bu sayfaya bağlı bir görünümü (view) döndürür.

**public IActionResult Privacy()
{
    return View();
}**

public IActionResult Privacy(): Bu metod, "Privacy" sayfasını döndüren bir aksiyondur. Gizlilik politikası gibi sayfalar için kullanılabilir.  

**[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public IActionResult Error()
{
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}**

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]: Bu satır, hata sayfası için bir önbellekleme (cache) stratejisi belirler. Bu sayfanın önbelleğe alınmamasını sağlar.  
Duration = 0: Önbellek süresi sıfırdır, yani sayfa önbelleğe alınmaz.  
Location = ResponseCacheLocation.None: Önbelleğin hiçbir yerde tutulmamasını sağlar.  
NoStore = true: Tarayıcının bu sayfayı depolamaması gerektiğini belirtir.  
public IActionResult Error(): Hata sayfasını döndüren aksiyon metodudur.  
return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });: Hata sayfasına bir ErrorViewModel ile birlikte döner. RequestId, hatanın izlenebilir olması için kullanılır.  

