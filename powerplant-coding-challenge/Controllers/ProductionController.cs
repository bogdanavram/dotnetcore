using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using powerplant_coding_challenge.Dtos;

namespace powerplant_coding_challenge.Controllers
{
    [ApiController]
    [Route("productionplan")]
    public class ProductionController : ControllerBase
    {      

        private readonly ILogger<ProductionController> _logger;

        public ProductionController(ILogger<ProductionController> logger )
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<ProductionPlanResultDto> Post([FromBody] ProductionPlanDto dto)
        {

             _logger.LogInformation("POST productionplan called.");

            try{

             var alg = new UnitCommitmentAlgorithm(dto);

            return alg.Process();

            }catch(Exception ex){

                _logger.LogError("Error :", ex);

                throw;
            }
        }
    }
}
