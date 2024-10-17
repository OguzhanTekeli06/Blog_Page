# ASP.NET Core MVC projesi,
Microsoft’un sunduğu bir framework olan ASP.NET Core ile web uygulamaları geliştirmek için kullanılan bir modeldir. MVC (Model-View-Controller) mimarisi, yazılımda modülerlik ve kodun daha düzenli olmasını sağlamak amacıyla kullanılır. Bu mimari, uygulamanın işleyişini 3 temel katmana ayırır:

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
 ## Veri Tabanı:

 
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
kodlarını çalıştırdık.    
( Çalışmazlarsa önce -> dotnet tool install --global dotnet-ef)    
Böylece veri tabanımız ve modellere göre tablolarımız oluşturulumuş oldu.

İndirilen Paketler:(bu komutlar ile)
dotnet add package Microsoft.EntityFrameworkCore  
dotnet add package Microsoft.EntityFrameworkCore.SqlServer  
dotnet add package Microsoft.EntityFrameworkCore.Design   



## Controller Detayları(Kategori ile ilgili kısımlar):

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

**public async Task<IActionResult> AddCategory(Category category){ //update metodunu ayrı yazmaya gerek yok
        if(category.Id == 0){
            await _context.AddAsync(category);
        }
        else{
            _context.Update(category);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Category));
    }**

* Bu metod, asenkron bir şekilde bir kategori eklemeye veya güncellemeye yarar.
* Category category: Bu metod, parametre olarak bir Category nesnesi alır. Bu nesne, 
 kategoriyle ilgili tüm verileri (örneğin adı, ID'si gibi) içerir.
* Burada, ekleme mi yoksa güncelleme mi yapılacağına karar veriliyor.
* category.Id == 0: Eğer kategorinin Id değeri 0 ise, bu, kategori veritabanında daha önce kaydedilmemiş (yeni) bir kayıt olduğunu gösterir. Dolayısıyla bu durumda bir ekleme işlemi yapılır.
* Eğer kategori yeni ise, AddAsync metodu kullanılarak kategori veritabanına eklenir. Bu işlem de asenkron olarak yapılır.
* Eğer Id sıfır değilse (kategori zaten var ise), o zaman bir güncelleme işlemi yapılır.
_context.Update(category): Burada, mevcut kategori güncellenir. Bu işlem asenkron değildir çünkü güncelleme işlemi bellekte hemen yapılabilir. Ancak değişikliklerin veritabanına kaydedilmesi için beklemek gerekecek.
* await _context.SaveChangesAsync(); Bu satır, yapılan ekleme veya güncelleme işlemlerinin veritabanına işlenmesini sağlar. SaveChangesAsync işlemi asenkron olarak gerçekleştirilir, bu da işlemin başarılı olmasını bekler.
* return RedirectToAction(nameof(Category)); İşlem tamamlandıktan sonra, RedirectToAction metodu kullanılarak kullanıcının Category sayfasına yönlendirilmesi sağlanır.
nameof(Category): Bu, metodun adını belirtir ve kullanıcının kategori listesine geri döneceğini gösterir.

**public async Task<IActionResult> CategoryDetails(int Id){
    var category = await _context.Category.FindAsync(Id);
    if (category == null){
        return NotFound(); // Eğer category null ise hata döndür
    }
    return Json(category);
}**

* public: Bu metodun erişim seviyesi herkese açıktır, yani başka sınıflar da bu metoda erişebilir.
* async: Bu metodun asenkron olduğunu belirtir, yani uzun süren işlemleri (örneğin veritabanı sorguları gibi) beklerken diğer işlemler devam edebilir. Böylece uygulama donmaz.
* Task<IActionResult>: Bu metodun dönüş tipi, bir asenkron görevdir (Task). Bu görev tamamlandığında, bir IActionResult döndürecektir. IActionResult, bir HTTP yanıtı türüdür ve genellikle bir web uygulamasında * işlem sonucu (JSON, View, Redirect vs.) döner.
* CategoryDetails(int Id): Bu metodun parametresi bir int türünden Id'dir. Bu, kategori ID'sini temsil eder ve ilgili kategori bilgilerini almak için kullanılır.
* var category: category adında bir değişken tanımlanır. Bu değişken, ilgili kategorinin veritabanındaki kaydını tutacaktır.
* await: await ifadesi, asenkron işlemin tamamlanmasını beklemek için kullanılır. Bu sayede bu satırda duraklama gerçekleşir ve veritabanı işlemi tamamlandıktan sonra devam eder.
* _context.Category: Bu, Entity Framework Core ile kullanılan veritabanı bağlamını (_context) temsil eder ve Category tablosuna erişimi sağlar.
* FindAsync(Id): Veritabanında Category tablosunda, verilen Id'ye sahip kaydı arar. Bu işlem asenkron olarak yapılır ve sonuçta kategori bulunursa category değişkenine atanır.
* if (category == null): Eğer veritabanında verilen Id'ye sahip bir kategori bulunamazsa, yani FindAsync işlemi null dönerse bu blok çalışır.
* return NotFound(): Eğer kategori bulunamazsa, HTTP 404 "Not Found" (Bulunamadı) hatası döndürülür. Bu, istemciye verilen ID'ye sahip bir kategori olmadığını bildirir.
*return Json(category): Eğer kategori bulunduysa, bu satırda o kategori bilgileri JSON formatında geri döndürülür. JSON, web API'lerinde yaygın olarak kullanılan bir veri formatıdır ve istemcinin bu veriyi kolayca işlemesine olanak sağlar.



**public async Task<IActionResult> DeleteCategory(int? Id){
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
}**

1. public async Task<IActionResult> DeleteCategory(int? Id)
Bu metod bir Task<IActionResult> türünde geri dönüş yapıyor, yani asenkron (async) çalışacak ve bir IActionResult döndürecek. Parametre olarak int? Id alıyor, bu da bu metodun nullable (boş olabilir) bir int alabileceği anlamına geliyor. Id silmek istediğin kategoriyi belirten kimlik (ID) numarasıdır.

2.if (Id == null)
{
    return NotFound(); // Eğer Id null ise, hata sayfası döndür
}
İlk olarak Id'nin null olup olmadığını kontrol ediyoruz. Eğer kullanıcı geçersiz bir Id gönderirse ya da hiç Id göndermezse, bu durumda NotFound() metodu çağrılıyor, yani "404 Not Found" hata sayfası geri dönüyor.

3.var category = await _context.Category.FindAsync(Id);
Eğer Id null değilse, bu satırda veritabanından bu Id'ye sahip kategoriyi arıyoruz. FindAsync(Id) metodu, asenkron olarak ilgili kategoriyi bulup category adlı değişkene atıyor.

4.if (category == null)
{
    return NotFound(); // Eğer bu Id'ye sahip bir kategori yoksa, hata sayfası döndür
}
Kategori bulunamazsa (örneğin, bu Id'ye sahip bir kategori veritabanında yoksa), yine bir "404 Not Found" hatası döndürülüyor.

5._context.Category.Remove(category); // Kategoriyi sil
Eğer kategori veritabanında bulunmuşsa, bu satırda Remove metodu kullanılarak veritabanından bu kategori siliniyor. Yani _context.Category.Remove(category) ile bu kategori silme işlemi için işaretleniyor.

6.await _context.SaveChangesAsync();   // Değişiklikleri veritabanına kaydet
Bu satırda, yapılan değişikliklerin (silme işleminin) veritabanına kalıcı olarak kaydedilmesi sağlanıyor. SaveChangesAsync metodu da asenkron olarak çalışıyor.

7.return RedirectToAction(nameof(Category)); // Silme işleminden sonra Category sayfasına yönlendir
Son olarak, silme işlemi tamamlandığında kullanıcıyı tekrar "Category" sayfasına yönlendiriyoruz. RedirectToAction metodu, belirttiğimiz başka bir metoda yönlendirme yapıyor ve burada Category metoduna dönüyoruz, yani kategori listesini tekrar gösteren sayfaya.

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

## Session İşlmeleri:
**dotnet add package Microsoft.Aspnetcore.Session**     
komutu ile paketimizi indiriyoruz.dotnet add package Microsoft.AspNetCore.Session, ASP.NET Core projelerinde oturum (session) yönetimi sağlamak için kullanılan bir NuGet paketini projeye ekler. Oturum yönetimi,  
  kullanıcıların uygulamanızda kalıcı bir şekilde veri saklamasına olanak tanır. Örneğin, bir kullanıcının oturumu boyunca çeşitli verilere erişimini sağlamak için kullanılabilir.

**Kullanım Amaçları:**
1. Kullanıcı Verisi Saklama: Kullanıcıların oturumları boyunca bazı verileri saklamak için kullanılabilir (örneğin, kullanıcı tercihleri, sepet bilgileri).

2. Oturum Süresi: Oturum süresi boyunca verilerin saklanmasını sağlar. Oturum, kullanıcı tarayıcısını kapatana veya belirli bir süre geçtikten sonra sona erebilir.

3. State Management (Durum Yönetimi): Uygulama içindeki kullanıcı durumunu yönetmek için kullanılır.

**Program.cs dosyasındaki eklemeler:** 

**builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
    options.Cookie.HttpOnly = true; // Çerez güvenliği
    options.Cookie.IsEssential = true; // Çerezin gerekli olduğunu belirt
});
app.UseSession();**

* builder.Services.AddSession(...)
Açıklama: Bu satır, ASP.NET Core uygulamanıza oturum yönetimi ekler. Oturum, kullanıcıların web uygulamanızda kimlik bilgileri ve diğer bilgileri saklamasına olanak tanır. Bu, kullanıcıların oturumları boyunca veri saklamak için kullanılır.
* options.IdleTimeout = TimeSpan.FromMinutes(30);
Açıklama: Bu ayar, kullanıcının oturumunun ne kadar süre boyunca etkin olmayacağını belirtir. Eğer kullanıcı 30 dakika boyunca hiçbir etkinlik gerçekleştirmezse, oturum zaman aşımına uğrayacaktır. Bu, güvenlik açısından önemlidir, çünkü oturumun uzun süre aktif kalmasını engeller.
* options.Cookie.HttpOnly = true;
Açıklama: Bu ayar, oturum çerezinin JavaScript tarafından erişilmesini engeller. Bu, XSS (Cross-Site Scripting) saldırılarına karşı bir güvenlik önlemidir. HttpOnly ayarı true olduğunda, çerez yalnızca sunucu tarafından erişilebilir ve istemci tarafında (örneğin, JavaScript) erişilemez.
* options.Cookie.IsEssential = true;
Açıklama: Bu ayar, çerezin gerekli olduğunu belirtir. Eğer bir kullanıcı çerezleri reddederse, IsEssential ayarı true olarak ayarlandığında, uygulama oturum çerezini yine de kullanmaya çalışır. Bu, uygulamanın belirli işlevselliği için çerezlere ihtiyaç duyduğu durumlarda kullanılır.

*app.UseSession() Middleware'inin İşlevi
Oturum Yönetimi: UseSession, kullanıcı oturumlarının yönetimini sağlar. Kullanıcı istekleri arasında oturum verilerini saklamanıza ve bu verilere erişmenize olanak tanır.
Oturum Verileri: Middleware, her bir isteğin başında oturum verilerini yükler ve istek tamamlandıktan sonra bu verileri güncelleyebilir. Böylece kullanıcı oturumunun sürekliliği sağlanır.
Zincirleme: Middleware'ler, UseRouting, UseAuthorization gibi diğer middleware'lerle birlikte çalışabilir ve belirli bir iş akışında yer alırlar.
Middleware Kullanımının Genel Yapısı
ASP.NET Core'da middleware'ler genellikle Configure metodunda aşağıdaki gibi sıralanır:

app.UseRouting();
app.UseSession(); // Oturum middleware'ini burada çağırıyoruz.
app.UseAuthorization();

Bu yapı, isteklerin sırayla nasıl işleneceğini belirler ve UseSession, diğer middleware'lerle birlikte çalışarak oturum yönetimini etkinleştirir.    
Oturum middleware'i, HTTP istekleri sırasında oturum bilgilerini yönetir. Bu, kullanıcı oturumu sırasında saklanan verilerin kullanılabilmesini sağlar. Middleware, isteklerin geldiği sırada oturum bilgilerini yükler ve yanıt sırasında günceller.

