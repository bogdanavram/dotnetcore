using System.Collections.Generic;
using System.Text.Json.Serialization;
using powerplant_coding_challenge.Models;

namespace powerplant_coding_challenge.Dtos {
public class ProductionPlanResultDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("p")]
        public decimal Power { get; set; }

         public List<PowerPlant> PowerPlants { get; set; }
    }
}