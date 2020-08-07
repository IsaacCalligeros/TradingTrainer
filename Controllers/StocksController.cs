using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Youkozi.Dtos.Stocks;
using static Youkozi.Dtos.Stocks.StocksData;

namespace Youkozi.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class StocksController : ControllerBase {
        private IConfiguration configuration;
        private IHttpClientFactory _factory;
        public StocksController (IConfiguration config, IHttpClientFactory factory) {
            configuration = config;
            _factory = factory;
        }

        [HttpGet ("GetCompany")]
        public async Task<IActionResult> GetCompany (string companyTicker) {
            var client = _factory.CreateClient ("finnHub");
            var news = await client.GetStringAsync ($"news?category=general");

            var stocksData = new List<StocksData> ();
            //companyTickers.Add("AAPL");

            //foreach(var ticker in companyTickers)
            //{
            var stockData = new StocksData ();
            var res = await client.GetStringAsync ($"quote?symbol=" + companyTicker);
            stockData = JsonConvert.DeserializeObject<StocksData> (res);
            var t = stockData.PreviousClose;
            //}

            return Ok (stocksData);
        }

    }
}