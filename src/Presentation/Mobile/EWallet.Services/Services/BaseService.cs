using EWallet.Mobile.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Mobile.Services.Services
{
    public class BaseService
    {

        protected async Task<ResultServiceModel<T>> Post<T>(string url, object model) where T : class
        {
            ResultServiceModel<T> resultService = new ResultServiceModel<T>();
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = GetHttpContent(model);

                HttpResponseMessage result = await client.PostAsync(url, content);
                if (result.IsSuccessStatusCode)
                {
                    var json_result = await result.Content.ReadAsStringAsync();
                    T obj = GetModelFromJson<T>(json_result);
                    resultService.Model = obj;
                }

                resultService.IsError = false;
            }
            catch (Exception ex)
            {
                resultService.IsError = true;
            }

            return resultService;
        }




        protected HttpContent GetHttpContent(object model)
        {
            string json = JsonConvert.SerializeObject(model);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        protected T GetModelFromJson<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
