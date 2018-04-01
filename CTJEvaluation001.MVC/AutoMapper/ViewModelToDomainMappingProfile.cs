using AutoMapper;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.MVC.ViewModels;

namespace CTJEvaluation001.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Observation, ObservationViewModel>();
            Mapper.CreateMap<SelfEvaluation, SelfEvaluationViewModel>();
            Mapper.CreateMap<ProfessionalDevelopment, ProfissionalDevelpmentViewModel>();
            Mapper.CreateMap<DigitalLiteracy, DigitalLiteracyViewModel>();
            Mapper.CreateMap<ProjectActivity, ProjectActivityViewModel>();
            Mapper.CreateMap<SelfEvalSave, SelfEvalSaveViewModel>();
            Mapper.CreateMap<AnnotationSave, AnnotationSaveViewModel>();
            Mapper.CreateMap<ObservationSave, ObservationSaveViewModel>();
            Mapper.CreateMap<ObservationSaveFinal, ObservationSaveFinalViewModel>();
            Mapper.CreateMap<ObservationDashboard, ObservationDashboardViewModel>();
            Mapper.CreateMap<ObservationDashboardDraw, ObservationDashboardDrawViewModel>();
        }
    }
}