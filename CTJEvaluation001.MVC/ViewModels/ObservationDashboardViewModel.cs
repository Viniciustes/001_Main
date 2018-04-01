using System.Collections.Generic;

namespace CTJEvaluation001.MVC.ViewModels
{
    public class ObservationDashboardViewModel
    {
        public IEnumerable<ObservationViewModel> observations { get; set; }
        public ObservationDashboardDrawViewModel observationDraw { get; set; }
    }
}