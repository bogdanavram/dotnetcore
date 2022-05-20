
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace powerplant_coding_challenge.Types {

    public enum PowerPlantType
    {
        [EnumMember(Value = "gasfired")] 
        [JsonPropertyName("gasfired")]
        GasFired,

        [EnumMember(Value = "turbojet")] 
        [JsonPropertyName("turbojet")]
        TurboJet,

        [EnumMember(Value = "windturbine")] 
        [JsonPropertyName("windturbine")]
        WindTurbine
    }
}
