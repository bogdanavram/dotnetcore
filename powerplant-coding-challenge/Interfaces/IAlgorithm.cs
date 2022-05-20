using System.Collections.Generic;
using powerplant_coding_challenge.Dtos;

namespace powerplant_coding_challenge.Interfaces
{

    public interface IAlgorithm {

        public IEnumerable<ProductionPlanResultDto> Process();

    }

}