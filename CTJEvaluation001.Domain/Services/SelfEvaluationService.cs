using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using CTJEvaluation001.Domain.Entities.Auth;
using System;

namespace CTJEvaluation001.Domain.Services
{
    public class SelfEvaluationService : ServiceBase<Observation>, ISelfEvaluationService
    {
        private readonly ISelfEvaluationRepository _selfEvaluationRepository;
        private readonly IFileUploadRepository _selfFileUploadRepository;
        private readonly IEmployeeRepository _selfEmployeeRepository;

        public SelfEvaluationService(ISelfEvaluationRepository selfEvaluationRepository,
            IFileUploadRepository selfFileUploadRepository,
            IEmployeeRepository selfEmployeeRepository)
            : base(selfEvaluationRepository)
        {
            _selfEvaluationRepository = selfEvaluationRepository;
            _selfFileUploadRepository = selfFileUploadRepository;
            _selfEmployeeRepository = selfEmployeeRepository;
        }

        public SelfEvaluation Get(Observed observed, int contextoAno)
        {
            var selfEvaluation = _selfEvaluationRepository.Get(observed, contextoAno);

            if (selfEvaluation == null)
            {
                return null;
            }

            /*if (selfEvaluation == null && contextoAno == Convert.ToInt32(DateTime.Now.Year.ToString()))
            {
                selfEvaluation = _selfEvaluationRepository.GenerateByYear(observed, contextoAno);
            }
            else if (selfEvaluation == null && contextoAno != Convert.ToInt32(DateTime.Now.Year.ToString()))
            {
                return null;
            }*/

            selfEvaluation.DegreeImage = _selfFileUploadRepository.GetById(selfEvaluation.DegreeImageId);

            // Question1
            var coursesQ1 = _selfEvaluationRepository.GetCourseParticipated(new int[] { 2, 3, 4 }, observed, contextoAno);

            foreach (var c in coursesQ1)
            {
                c.Classes = _selfEvaluationRepository.GetClassesParticipatedByCourseId(int.Parse(c.Id), observed, contextoAno);
            }

            var ctjEventsQ1 = new CTJEvents();
            ctjEventsQ1.Courses = coursesQ1;

            selfEvaluation.Question1 = ctjEventsQ1;

            // Question2
            var coursesQ2 = _selfEvaluationRepository.GetCourseParticipated(new int[] { 5, 6 }, observed, contextoAno);

            foreach (var c in coursesQ2)
            {
                c.Classes = _selfEvaluationRepository.GetClassesParticipatedByCourseId(int.Parse(c.Id), observed, contextoAno);
            }

            var ctjEventsQ2 = new CTJEvents();
            ctjEventsQ2.Courses = coursesQ2;

            selfEvaluation.Question2 = ctjEventsQ2;

            // Question2A
            var coursesQ2A = _selfEvaluationRepository.GetCourseParticipated(new int[] { 7 }, observed, contextoAno);

            foreach (var c in coursesQ2A)
            {
                c.Classes = _selfEvaluationRepository.GetClassesParticipatedByCourseId(int.Parse(c.Id), observed, contextoAno);
            }

            var ctjEventsQ2A = new CTJEvents();
            ctjEventsQ2A.Courses = coursesQ2A;

            selfEvaluation.Question2A = ctjEventsQ2A;

            selfEvaluation.ProfessionalDevelopments = _selfEvaluationRepository.GetProfessionalDevelopmentByAnoAndChapa(observed, contextoAno);

            foreach (var item in selfEvaluation.ProfessionalDevelopments)
            {
                item.Imagem = _selfFileUploadRepository.GetById(item.ImagemId);
            }

            selfEvaluation.DigitalLiteracies = _selfEvaluationRepository.GetDigitalLiteracyByAnoAndChapa(observed, contextoAno);
            selfEvaluation.ProjectActivities = _selfEvaluationRepository.GetProjectActivityByAnoAndChapa(observed, contextoAno);

            selfEvaluation.DegreeComplete = 0;
            var person = _selfEmployeeRepository.GetPersonByChapa(observed.ObservedId);
            List<string> options = new List<string>(new string[] { "9", "A", "B", "C", "D", "E", "F", "G", "H" });

            foreach (var item in options)
            {
                if(person.GrauInstrucao.ToUpper() == item.ToUpper())
                {
                    selfEvaluation.DegreeComplete = 1;
                    selfEvaluation.Degree = 1;
                    break;
                }
            }

            return selfEvaluation;
        }

        public DigitalLiteracy Save(DigitalLiteracy obj, AuthUser authUser)
        {
            return obj.Nseq != null ? _selfEvaluationRepository.Update(obj, obj.Ano, obj.Nseq, authUser) : _selfEvaluationRepository.Save(obj, authUser);
        }

        public ProfessionalDevelopment Save(ProfessionalDevelopment obj, AuthUser authUser)
        {
            return obj.Nseq != null ? _selfEvaluationRepository.Update(obj, obj.Ano, obj.Tipo, obj.Nseq, authUser) : _selfEvaluationRepository.Save(obj, authUser);
        }

        public ProjectActivity Save(ProjectActivity obj, AuthUser authUser)
        {
            Remove(obj, authUser);

            return _selfEvaluationRepository.Save(obj, authUser);
        }

        public ProjectActivity Remove(ProjectActivity obj, AuthUser authUser)
        {
            return _selfEvaluationRepository.Remove(obj, authUser);
        }

        public ProfessionalDevelopment Remove(ProfessionalDevelopment obj, AuthUser authUser)
        {
            return _selfEvaluationRepository.Remove(obj, authUser);
        }

        public DigitalLiteracy Remove(DigitalLiteracy obj, AuthUser authUser)
        {
            return _selfEvaluationRepository.Remove(obj, authUser);
        }

        public SelfEvalSave Save(SelfEvalSave obj, AuthUser authUser)
        {
            return _selfEvaluationRepository.Save(obj, authUser);
        }

        public FileUpload GetById(int? id)
        {
            return _selfFileUploadRepository.GetById(id);
        }

        public IEnumerable<SelfEvaluation> GetAllByObserver(Observer observer, int contextoAno)
        {
            return _selfEvaluationRepository.GetAllByObserver(observer, contextoAno);
        }
    }
}