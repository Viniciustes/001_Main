using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Entities
{
    public class ObservationDashboard
    {
        public IEnumerable<Observation> observations { get; set; }
        public ObservationDashboardDraw observationDraw { get; set; }
    }
}
