using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using powerplant_coding_challenge.Dtos;
using powerplant_coding_challenge.Interfaces;

namespace powerplant_coding_challenge.Controllers
{
    [ApiController]
    [Route("productionplan")]
    public class ProductionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductionController> _logger;

        public ProductionController(ILogger<ProductionController> logger )
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<ProductionPlanResultDto> Post([FromBody] ProductionPlanDto dto)
        {
             var alg = new UnitCommitmentAlgorithm(dto);
            return alg.Process();
        }
    }
}
