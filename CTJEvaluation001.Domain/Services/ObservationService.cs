using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using CTJEvaluation001.Domain.Entities.Auth;
using System;

namespace CTJEvaluation001.Domain.Services
{
    public class ObservationService : ServiceBase<Observation>, IObservationService
    {
        private readonly IObservationRepository _observationRepository;

        public ObservationService(IObservationRepository observationRepository) 
            : base(observationRepository)
        {
            _observationRepository = observationRepository;
        }

        public IEnumerable<Observation> GetAll(AuthUser authUser, int contextoAno)
        {
            var observations = _observationRepository.GetAll(authUser, contextoAno);

            var enumerable = observations as Observation[] ?? observations.ToArray();
            foreach (var observation in enumerable)
            {
                observation.Observer = _observationRepository.GetObserver(observation.ObserverId);
                observation.Observed = _observationRepository.GetObserved(observation.ObservedId);
            }

            return enumerable;
        }

        public IEnumerable<Observation> GetAllByObserver(AuthUser authUser, int contextoAno)
        {
            var observations = _observationRepository.GetAllByObserver(authUser, contextoAno);

            var allByObserver = observations as Observation[] ?? observations.ToArray();
            foreach (var observation in allByObserver)
            {
                observation.Observer = _observationRepository.GetObserver(observation.ObserverId);
                observation.Observed = _observationRepository.GetObserved(observation.ObservedId);
            }

            return allByObserver;
        }

        public Observation GetById(AuthUser authUser, string id)
        {
            var observation = _observationRepository.GetById(authUser, id);

            observation.TeacherObservationReport = _observationRepository.GetTeacherObservationReport(observation.CodAvaliacao, observation.ObservedId, observation.ObserverId);
            observation.Observer = _observationRepository.GetObserver(observation.ObserverId);
            observation.Observed = _observationRepository.GetObserved(observation.ObservedId);
            observation.FinalComments = _observationRepository.GetFinalComments(observation.CodAvaliacao, observation.ObservedId, observation.ObserverId);
            observation.Competences = _observationRepository.GetCompetences(observation.CodAvaliacao);

            foreach (var item in observation.Competences)
            {
                item.Performances = _observationRepository.GetPerformances(observation.CodAvaliacao, observation.ObservedId, observation.ObserverId, item.Id);
            }

            return observation;
        }

        public Observation GetByIdObserver(AuthUser authUser, string id)
        {
            var observation = _observationRepository.GetByIdObserver(authUser, id);

            //var observerObserved = _observationRepository.getObservedObserver(observation.ObservedId, observation.ObserverId);

            observation.TeacherObservationReport = _observationRepository.GetTeacherObservationReport(observation.CodAvaliacao, observation.ObservedId, observation.ObserverId);
            observation.Observer = _observationRepository.GetObserver(observation.ObserverId);
            observation.Observed = _observationRepository.GetObserved(observation.ObservedId);
            observation.FinalComments = _observationRepository.GetFinalComments(observation.CodAvaliacao, observation.ObservedId, observation.ObserverId);
            observation.Competences = _observationRepository.GetCompetences(observation.CodAvaliacao);
            observation.Escalas = _observationRepository.GetEscalaByAvaliacao(observation.CodAvaliacao);

            foreach (var item in observation.Competences)
            {
                item.Performances = _observationRepository.GetPerformances(observation.CodAvaliacao, observation.ObservedId, observation.ObserverId, item.Id);
            }

            return observation;
        }

        public ObservationSave Save(AuthUser authUser, ObservationSave observation)
        {
            return _observationRepository.Save(authUser, observation);
        }

        public ObservationSave Done(AuthUser authUser, ObservationSave observation)
        {
            return _observationRepository.Done(authUser, observation);
        }

        public ObservationSaveFinal SaveF(AuthUser authUser, ObservationSaveFinal observation)
        {
            return _observationRepository.SaveF(authUser, observation);
        }

        public ObservationSaveFinal DoneF(AuthUser authUser, ObservationSaveFinal observation)
        {
            return _observationRepository.DoneF(authUser, observation);
        }

        public ObservationDashboard GetObservationDashboard(AuthUser authUser, int contextoAno)
        {
            var observations = GetAllByObserver(authUser, contextoAno);
            var observationDraw = GetObservationDashboardDraw(authUser, contextoAno);

            ObservationDashboard observationDashboard = new ObservationDashboard();

            observationDashboard.observations = observations;
            observationDashboard.observationDraw = observationDraw;

            return observationDashboard;
        }

        public ObservationDashboardDraw GetObservationDashboardDraw(AuthUser authUser, int contextoAno)
        {
            return _observationRepository.GetObservationDashboardDraw(authUser, contextoAno);
        }
    }
}
