using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Services
{
    public interface IObservationService : IServiceBase<Observation>
    {
        Observation GetById(AuthUser authUser, string id);
        Observation GetByIdObserver(AuthUser authUser, string id);
        ObservationSave Save(AuthUser authUser, ObservationSave observation);
        ObservationSave Done(AuthUser authUser, ObservationSave observation);
        ObservationSaveFinal SaveF(AuthUser authUser, ObservationSaveFinal observation);
        ObservationSaveFinal DoneF(AuthUser authUser, ObservationSaveFinal observation);
        IEnumerable<Observation> GetAll(AuthUser authUser, int contextoAno);
        IEnumerable<Observation> GetAllByObserver(AuthUser authUser, int contextoAno);
        ObservationDashboard GetObservationDashboard(AuthUser authUser, int contextoAno);
        ObservationDashboardDraw GetObservationDashboardDraw(AuthUser authUser, int contextoAno);
    }
}
