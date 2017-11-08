using HtmlParser.Data;
using System;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public interface ILoader
    {
        int ResponseCode { get;}
        Task<string> GetPage();
        event EventHandler<HttpResponce> ResponseReceived;
    }
}
