using System.Net.Http;
using System.Threading.Tasks;

namespace ShoesWebsite.Helpers
{
    public interface IHttpHelper
    {
        Task<TResponse> Send<TResponse>(string url, HttpMethod method, object data = null);
        Task<bool> Send(string url, HttpMethod method);
    }
}
