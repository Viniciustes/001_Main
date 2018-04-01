using System;
using System.Collections.Generic;
using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using CTJEvaluation001.Domain.Interfaces.Services;

namespace CTJEvaluation001.Application
{
    public class ObservationAppService : AppServiceBase<Observation>, IObservationAppService
    {
        private readonly IObservationService _observationService;
        private readonly IObserverService _observerService;

        public ObservationAppService(IObservationService observationBase, IObserverService observerService) 
            : base(observationBase)
        {
            _observationService = observationBase;
            _observerService = observerService;
        }

        public Observation GetById(AuthUser authUser, string id)
        {
            return _observationService.GetById(authUser, id);
        }

        public IEnumerable<Observation> GetAll(AuthUser authUser, int contextoAno)
        {
            return _observationService.GetAll(authUser, contextoAno);
        }

        public IEnumerable<Observation> GetAllByObserver(AuthUser authUser, int contextoAno)
        {
            return _observationService.GetAllByObserver(authUser, contextoAno);
        }

        public Observation GetByIdObserver(AuthUser authUser, string id)
        {
            return _observationService.GetByIdObserver(authUser, id);
        }

        public ObservationSave Save(AuthUser authUser, ObservationSave observation)
        {
            return _observationService.Save(authUser, observation);
        }

        public ObservationSave Done(AuthUser authUser, ObservationSave observation)
        {
            return _observationService.Done(authUser, observation);
        }

        public ObservationSaveFinal SaveF(AuthUser authUser, ObservationSaveFinal observation)
        {
            return _observationService.SaveF(authUser, observation);
        }

        public ObservationSaveFinal DoneF(AuthUser authUser, ObservationSaveFinal observation)
        {
            return _observationService.DoneF(authUser, observation);
        }

        public Observer GetByChapa(string chapa)
        {
            return _observerService.GetByChapa(chapa);
        }

        public ObservationDashboard GetObservationDashboard(AuthUser authUser, int contextoAno)
        {
            return _observationService.GetObservationDashboard(authUser, contextoAno);
        }
    }
}
