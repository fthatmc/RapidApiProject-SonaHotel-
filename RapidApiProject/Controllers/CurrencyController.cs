using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class CurrencyController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com18.p.rapidapi.com/exchange-rates?baseCurrency=TRY"),
                Headers =
    {
        { "X-RapidAPI-Key", "df4a14f685msh5ad17fc6cf3dbc8p13d803jsn0a6b0451f5f6" },
        { "X-RapidAPI-Host", "booking-com18.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.data.exchange_rates.ToList());
            }
           
        }
    }
}
