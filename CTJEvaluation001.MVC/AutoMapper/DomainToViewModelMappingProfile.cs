using AutoMapper;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.MVC.ViewModels;

namespace CTJEvaluation001.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ObservationViewModel, Observation>();
            Mapper.CreateMap<SelfEvaluationViewModel, SelfEvaluation>();
            Mapper.CreateMap<ProfissionalDevelpmentViewModel, ProfessionalDevelopment>();
            Mapper.CreateMap<DigitalLiteracyViewModel, DigitalLiteracy>();
            Mapper.CreateMap<ProjectActivityViewModel, ProjectActivity>();
            Mapper.CreateMap<SelfEvalSaveViewModel, SelfEvalSave>();
            Mapper.CreateMap<AnnotationSaveViewModel, AnnotationSave>();
            Mapper.CreateMap<ObservationSaveViewModel, ObservationSave>();
            Mapper.CreateMap<ObservationSaveFinalViewModel, ObservationSaveFinal>();
            Mapper.CreateMap<ObservationDashboardViewModel, ObservationDashboard>();
            Mapper.CreateMap<ObservationDashboardDrawViewModel, ObservationDashboardDraw>();
        }
    }
}