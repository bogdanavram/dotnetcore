using System.Collections.Generic;
using System.Text.Json.Serialization;
using powerplant_coding_challenge.Models;

namespace powerplant_coding_challenge.Dtos {
public class ProductionPlanDto
    {
        [JsonPropertyName("load")]
        public int Load { get; set; }

        [JsonPropertyName("fuels")]
        public Fuels Fuels { get; set; }

        [JsonPropertyName("powerplants")]
        public List<PowerPlant> PowerPlants { get; set; }
    }
}