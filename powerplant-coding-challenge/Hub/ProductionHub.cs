
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using powerplant_coding_challenge.Dtos;

namespace powerplant_coding_challenge
{
    public class ProductionHub : Microsoft.AspNetCore.SignalR.Hub
    {
        readonly ILogger<ProductionHub> logger;

        public ProductionHub(ILogger<ProductionHub> logger)
        {
            this.logger = logger;
        }       


        public async Task Calculate( ProductionPlanDto dto) {    
            var alg = new UnitCommitmentAlgorithm(dto);

            alg.Process();        
                
            await Clients.Caller.SendAsync("ReceiveMessage", Context.ConnectionId, alg.Process());                
        }
    }  
        
}
