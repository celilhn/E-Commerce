using Application.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace Application.Utilities
{
    public class HttpUtilities : IHttpUtilities
    {

        private readonly IApiLogger logger;
        public HttpUtilities(IApiLogger logger)
        {
            this.logger = logger;
        }

        public string ExecuteHttpRequest(string endpoint, string requestBody, Method method, DataFormat dataFormat, Dictionary<string, string> headers = null)
        {
            DateTime startDate = DateTime.Now;
            string response = "";
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            try
            {
                var request = new RestRequest("", method);
                var client = new RestClient(endpoint);
                if ("" + requestBody != "")
                {
                    request.AddBody(requestBody, "application/json");
                }
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }
                RestResponse restResponse = client.ExecuteAsync(request).GetAwaiter().GetResult();
                if (restResponse != null)
                {
                    response = restResponse.Content;
                    httpStatusCode = restResponse.StatusCode;
                }
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                throw;
            }
            finally
            {
                LogDetail logDetail = new LogDetail();
                logDetail.StartDate = startDate;
                logDetail.Endpoint = endpoint;
                logDetail.Request = requestBody;
                logDetail.EndDate = DateTime.Now;
                logDetail.HttpStatusCode = httpStatusCode;
                logDetail.Response = response;
                logger.Log(logDetail);
            }
            return response;
        }

        public string ExecuteHttpRequest(string endpoint, string requestBody, Dictionary<string, string> headers = null)
        {
            DateTime startDate = DateTime.Now;
            string response = "";
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            try
            {
                var request = new RestRequest("", Method.Post);
                request.RequestFormat = DataFormat.Json;
                var client = new RestClient(endpoint);
                request.AddBody(requestBody, "application/json");
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }
                RestResponse restResponse = client.ExecutePostAsync(request).GetAwaiter().GetResult();
                if (restResponse != null)
                {
                    response = restResponse.Content;
                    httpStatusCode = restResponse.StatusCode;
                }
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                throw;
            }
            finally
            {
                LogDetail logDetail = new LogDetail();
                logDetail.StartDate = startDate;
                logDetail.Endpoint = endpoint;
                logDetail.Request = requestBody;
                logDetail.EndDate = DateTime.Now;
                logDetail.HttpStatusCode = httpStatusCode;
                logDetail.Response = response;
                logger.Log(logDetail);
            }
            return response;
        }
    }
}
