using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IObservationRepository : IRepositoryBase<Observation>
    {
        IEnumerable<Observation> GetAll(AuthUser authUser, int contextoAno);
        IEnumerable<Observation> GetAllByObserver(AuthUser authUser, int contextoAno);
        Observation GetById(AuthUser authUser, string id);
        Observation GetByIdObserver(AuthUser authUser, string id);
        Observed GetObserved(string id);
        Observer GetObserver(string id);
        ObservationSave Save(AuthUser authUser, ObservationSave observation);
        ObservationSaveFinal SaveF(AuthUser authUser, ObservationSaveFinal observation);
        ObservationSave Done(AuthUser authUser, ObservationSave observation);
        ObservationSaveFinal DoneF(AuthUser authUser, ObservationSaveFinal observation);
        //ObserverObserved getObservedObserver(string idObserved, string idObserver);
        TeacherObservationReport GetTeacherObservationReport(string codAvaliacao, string observedId, string observerId);
        IEnumerable<FinalComments> GetFinalComments(string codAvaliacao, string observedId, string observerId);
        IEnumerable<Competence> GetCompetences(string codAvaliacao);
        IEnumerable<Performance> GetPerformances(string codAvaliacao, string observedId, string observerId, string competenceId);
        IEnumerable<Escala> GetEscalaByAvaliacao(string id);
        ObservationDashboardDraw GetObservationDashboardDraw(AuthUser authUser, int contextoAno);
    }
}