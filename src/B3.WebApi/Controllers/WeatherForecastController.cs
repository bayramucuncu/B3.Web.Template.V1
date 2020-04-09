using System;
using System.Threading.Tasks;
using B3.WebApi.Security;
using Microsoft.AspNetCore.Mvc;

namespace B3.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public WeatherForecastController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok(Summaries));
        }
    }
}
