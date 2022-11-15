using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.data;
using webapi.DTO;
namespace MyMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MeetsService _meetsService;
          private readonly SPService _spService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,MeetsService meetsService,SPService spService)
        {
            _logger = logger;
            _meetsService=meetsService;
            _spService=spService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<List<Meet>> xxx([FromBody] Meet meet) {
           await _meetsService.CreateAsync(meet);
            return await _meetsService.GetAsync();
        }
        
        [HttpGet]
        [Route("[action]")]
        //public async Task<List<Meet>> UpdateList([FromBody] Meet meet) {
            public async Task<List<Meet>> UpdateList() {
//              meet=  new Meet{
//                Id=2,
//                Name="boazgn",
//                inMeeating= new MeetIn [1].Select(h => new MeetIn{
//                     addess="klh 78",
//                     city="jer",
//                     desc="jjj",
//                     startDate=DateTime.Now,
// endDate=DateTime.Now.AddDays(1)
//                }).ToList()
//               };
          // await _meetsService.UpdateAsync(meet.Id,meet);
           // return await _meetsService.UpdateFilterAsync("jerccr");
           return await _spService.UpdateFilterAsync();
        }
      
    }
}
