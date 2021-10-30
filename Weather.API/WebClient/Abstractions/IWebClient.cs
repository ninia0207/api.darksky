using System.Threading.Tasks;

namespace WebClient.Abstractions
{
    public interface IWebClient
    {
        public Task<string> GetDataAsync();
    }
}
