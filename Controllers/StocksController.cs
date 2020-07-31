using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ThreeFourteen.Finnhub.Client;

namespace TradingTrainer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private IConfiguration configuration;
        public StocksController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpGet("index")]
        public string Index()
        {
            return "Hello from the Stocks controller";
        }

        [HttpGet("testing")]
        [AllowAnonymous]
        public string testing()
        {
            var key = configuration["finnHubKey"];
            var client = new FinnhubClient(key);

            return "hello";
        }
    }
}