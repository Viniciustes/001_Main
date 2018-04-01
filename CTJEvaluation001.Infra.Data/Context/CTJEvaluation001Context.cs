using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Infra.Data.EntityConfig;
using CTJEvaluation001.Infra.Data.EntityConfig.Auth;
using CTJEvaluation001.Reports.ReportModel;
using System.Data.Entity;

namespace CTJEvaluation001.Infra.Data.Context
{
    public class CTJEvaluation001Context : DbContext
    {
        public CTJEvaluation001Context()
            : base ("CTJEvaluation001")
        {
            Database.SetInitializer<CTJEvaluation001Context>(null);
        }

        public DbSet<Observation> Observations { get; set; }
        public DbSet<RapReportAnnotation> RapReportAnnotations { get; set; }
        public DbSet<RapReportClass> RapReportClasss { get; set; }
        public DbSet<RapReportFalta> RapReportFaltas { get; set; }
        public DbSet<TeacherObservationReport> TeacherObservationReport { get; set; }
        public DbSet<Observed> Observed { get; set; }
        public DbSet<Observer> Observer { get; set; }
        //public DbSet <ObserverObserved> ObserverObserved { get; set; }
        public DbSet<FinalComments> FinalComments { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<SelfEvaluation> SelfEvaluation { get; set; }
        public DbSet<ProfessionalDevelopment> ProfessionalDevelopment { get; set; }
        public DbSet<DigitalLiteracy> DigitalLiteracies { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<User> User { get; set; }
        //public DbSet<ProjectActivity> ProfessionalAttitudies { get; set; }
        public DbSet<SelfEvalSave> SelfEvalSave { get; set; }
        public DbSet<AnnotationType> AnnotationType { get; set; }
        public DbSet<Escala> Escalas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ObservationConfiguration());
            modelBuilder.Configurations.Add(new ObserverConfiguration());
            modelBuilder.Configurations.Add(new ObservedConfiguration());
            modelBuilder.Configurations.Add(new TeacherObservationReportConfiguration());
            modelBuilder.Configurations.Add(new FinalCommentsConfiguration());
            modelBuilder.Configurations.Add(new CompetenceConfiguration());
            modelBuilder.Configurations.Add(new PerformanceConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ClassConfiguration());
            modelBuilder.Configurations.Add(new SelfEvaluationConfiguration());
            modelBuilder.Configurations.Add(new ProfessionalDevelopmentConfiguration());
            modelBuilder.Configurations.Add(new DigitalLiteracyConfiguration());
            modelBuilder.Configurations.Add(new FileUploadConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SelfEvalSaveConfiguration());
            modelBuilder.Configurations.Add(new AuthUserConfiguration());
            modelBuilder.Configurations.Add(new AnnotationConfiguration());
            modelBuilder.Configurations.Add(new AnnotationTypeConfiguration());
        }
    }
}
