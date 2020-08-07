using Microsoft.AspNetCore.Mvc;

namespace Youkozi.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class Home : ControllerBase {
        [HttpGet]
        public string Index () {
            return "Hello from the home controller";
        }
    }
}