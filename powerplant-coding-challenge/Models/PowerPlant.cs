
using powerplant_coding_challenge.Types;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace powerplant_coding_challenge.Models {
public class PowerPlant
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public PowerPlantType Type { get; set; }

        [JsonPropertyName("efficiency")]
        public decimal Efficiency { get; set; }

        [JsonPropertyName("pmin")]
        public decimal Pmin { get; set; }

        [JsonPropertyName("pmax")]
        public decimal Pmax { get; set; }

        [JsonIgnore]
         public decimal Price { get; set; }

         [JsonIgnore]
         public decimal PowerToGenerate { get; set; }
    }
}