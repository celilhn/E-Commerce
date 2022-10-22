using RestSharp;
using System.Collections.Generic;


namespace Application.Interfaces
{
    public interface IHttpUtilities
    {
        string ExecuteHttpRequest(string endpoint, string requestBody, Method method, DataFormat dataFormat, Dictionary<string, string> headers = null);
        string ExecuteHttpRequest(string endpoint, string requestBody, Dictionary<string, string> headers = null);
    }
}
