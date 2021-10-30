using System.Net.Http;
using System.Threading.Tasks;
using WebClient.Abstractions;

namespace WebClient.Implementations
{
    public class WebClient : IWebClient
    {
        
        public string URL { get; set; }

        public WebClient(string url)
        {
            URL = url;
        }


        public async Task<string> GetDataAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var content = await httpClient.GetStringAsync(URL);
                return content;
            }
        }
    }
}
