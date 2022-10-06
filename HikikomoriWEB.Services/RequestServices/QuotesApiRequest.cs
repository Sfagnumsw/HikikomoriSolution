using System;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace HikikomoriWEB.Services.RequestServices
{
    public class QuotesApiRequest
    {
        public static async Task<ApiQuoteData> Quote()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://movies-quotes.p.rapidapi.com/quote"),
                Headers =
                {
                    { "X-RapidAPI-Key", "dd794a4204mshf290cb22156b9a4p17e39cjsn95e339e2f71d" },
                    { "X-RapidAPI-Host", "movies-quotes.p.rapidapi.com" },
                }
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var data = JObject.Parse(await response.Content.ReadAsStringAsync());
                return new ApiQuoteData()
                {
                    Quote = data["quote"].Value<string>(),
                    Сharacter = data["character"].Value<string>(),
                    Show = data["show"].Value<string>()
                };
            }
        }
    }
    
}
