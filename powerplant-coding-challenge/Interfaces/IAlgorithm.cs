using System.Collections.Generic;
using powerplant_coding_challenge.Dtos;
using powerplant_coding_challenge.Models;

namespace powerplant_coding_challenge.Interfaces {

    public interface IAlgorithm {

        public IEnumerable<ProductionPlanResultDto> Process();

    }

}