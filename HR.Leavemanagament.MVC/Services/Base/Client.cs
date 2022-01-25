
using System.Net.Http;
namespace HR.Leavemanagament.MVC.Services
{
    public partial class Client: IClient
    {
       
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
