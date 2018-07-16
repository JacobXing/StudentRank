using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcAngular;
using RankAPI.Dtos;
using System.Net.Http;
using Newtonsoft.Json;
using Serilog;

namespace RankAPI.Controllers
{
    [Angular, Route("[controller]/[action]")]
    public class ProxyController : Controller
    {
        private readonly AzureMLRequestOptions _azureMLRequestOptions;
        private readonly ILogger _logger;
        public ProxyController(AzureMLRequestOptions azureMLRequestOptions, ILogger logger)
        {
            _azureMLRequestOptions = azureMLRequestOptions;
            _logger = logger;
        }

        [HttpPost]
        public async Task<AzureMLRankResponse> Infer([FromBody] AzureMLRankRequest azureMLRankRequest)
        {
            _logger.Information("Request Object is {@request}", azureMLRankRequest);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_azureMLRequestOptions.Key}");
                var content = new StringContent(JsonConvert.SerializeObject(azureMLRankRequest), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(_azureMLRequestOptions.Url, content);
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AzureMLRankResponse>(json);
                return result;
            }
        }
    }
}
