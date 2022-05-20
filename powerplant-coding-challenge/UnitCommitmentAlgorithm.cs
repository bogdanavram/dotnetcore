using System;
using System.Collections.Generic;
using System.Linq;
using powerplant_coding_challenge.Dtos;
using powerplant_coding_challenge.Interfaces;
using powerplant_coding_challenge.Models;
using powerplant_coding_challenge.Types;

namespace powerplant_coding_challenge{

    public class UnitCommitmentAlgorithm : IAlgorithm
    {

        private  ProductionPlanDto _productionPlanPayload;

        public UnitCommitmentAlgorithm(ProductionPlanDto productionPlanPayload){
            _productionPlanPayload = productionPlanPayload;
        }
        public IEnumerable<ProductionPlanResultDto> Process(){

           var l1 =  _productionPlanPayload.PowerPlants.Where(p=>p.Type == PowerPlantType.WindTurbine).Select(p => {p.Pmax = p.Pmax * this.WindPercentage; p.Price = 0; return p;}).ToList();

           var l2 =  _productionPlanPayload.PowerPlants.Where(p=>p.Type == PowerPlantType.GasFired ).Select(p => {p.Price = this.GasPrice / p.Efficiency; return p;}).ToList();

           var l3 =  _productionPlanPayload.PowerPlants.Where(p=>p.Type == PowerPlantType.TurboJet ).Select(p => {p.Price = this.KerosinePrice / p.Efficiency; return p;}).ToList();

           _productionPlanPayload.PowerPlants = l1.Concat(l2).Concat(l3).ToList();

           // order plants by lower price and high power
          var orderedPlants =  _productionPlanPayload.PowerPlants.OrderBy(p=>p.Price).ThenBy(p=>p.Pmax).ToList();

         decimal requestedLoad = this._productionPlanPayload.Load;
   
          foreach(var p in orderedPlants){
               if (requestedLoad <=0) {                  
                   p.PowerToGenerate = 0;
                   continue;
               }
              if (requestedLoad < p.Pmin){                     
                      p.PowerToGenerate = p.Pmin;
                      requestedLoad = requestedLoad - p.Pmin;
                        }
                    else
                        if (p.Pmax > requestedLoad){                             
                             p.PowerToGenerate = requestedLoad;
                            requestedLoad = requestedLoad - requestedLoad;
                        }
                        else{          
                            p.PowerToGenerate = p.Pmax;
                            requestedLoad = requestedLoad - p.Pmax;
                        }
            }

            decimal powerGenerated = orderedPlants.Sum(p=>p.PowerToGenerate);
            if (powerGenerated > this._productionPlanPayload.Load) BalancerPower(orderedPlants, powerGenerated - this._productionPlanPayload.Load);

           return orderedPlants.Select(p => new ProductionPlanResultDto{Name = p.Name, Power = p.PowerToGenerate}); 
        }

        //Distributes excess power among the plants
        private void BalancerPower(List<PowerPlant> solution, decimal powerExcess){

            var orderedPlants =  _productionPlanPayload.PowerPlants.OrderByDescending(p=>p.Price).ThenBy(p=>p.Pmax).ToList();
            foreach(var p in orderedPlants){
                if (powerExcess == 0) break;

                if ((p.PowerToGenerate - powerExcess) >= p.Pmin) {
                    p.PowerToGenerate =  p.PowerToGenerate - powerExcess;
                    powerExcess = 0;
                }
                else{
                 powerExcess = powerExcess - (p.PowerToGenerate - p.Pmin);
                 p.PowerToGenerate =  p.Pmin;
                }
             }
        }


        private decimal WindPercentage { get {return Decimal.Divide(this._productionPlanPayload.Fuels.Wind, 100); } }

        private decimal GasPrice { get {return this._productionPlanPayload.Fuels.GasEuroMWh; } }

        private decimal KerosinePrice { get {return this._productionPlanPayload.Fuels.KerosineEuroMWh; } }       
            
       
    }
}