using Microsoft.AspNetCore.Mvc;
using MyApiProject.WebUI.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace MyApiProject.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient(); //bir istek oluşturuyoruz
            var responseMessage = await client.GetAsync("https://localhost:7274/api/Category"); //isteğin yanıtını karşılayacak olan bir değişken oluşturuyoruz (async olduğu için await kullandık). GetAsync 'HttpGet' e karşılık gelen istek türü.Burada verileri uı katmanına çekerken bu adrese istekte bulunacağız anlamına geliyor.
            if (responseMessage.IsSuccessStatusCode) //başarılı durum kodu başarılı dönerse
            {
                //api json formatında veri döndürür, responsemessage içindeki verileri string olarak döndür anlamına gelir  
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //json convert ile gelen liste (category verileri var ve bu liste jsondata içinde) dönüşüm yapıyoruz. List içine sınıf atayacağımız bu sınıf categorylerle eşleşmesi gereken bir sınıf olması gerekir
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto); //Create işleminde responeMessage da PostAsync serialize edeceğimiz içeriği ister o yüzden bu işlemi yapmadan önce serialize etme işlemini gerçekleştirmeliyiz
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json"); // json data dan gelen veriyi PostAsync içinde işleyebilmemiz için StringContent türünde bir format daha istiyor 
            var responseMessage = await client.PostAsync("https://localhost:7274/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7274/api/Category?id=" + id); //?id = bizim gönderdiğimiz id ye
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }
    }
}
