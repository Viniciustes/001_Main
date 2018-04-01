[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CTJEvaluation001.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CTJEvaluation001.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace CTJEvaluation001.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application;
    using Application.Interface;
    using Domain.Interfaces.Services;
    using Domain.Services;
    using Domain.Interfaces.Repositories;
    using Infra.Data.Repositories;
    using Infra.CrossCutting.Interfaces;
    using Infra.CrossCutting.Services;
    using Infra.Data.Repositories.Auth;
    using Domain.Interfaces.Repositories.Auth;
    using Domain.Services.Auth;
    using Domain.Interfaces.Services.Auth;
    using Reports.Interfaces.Services;
    using Reports.Services;
    using Infra.Data.Repositories.Reports;
    using Reports.Interfaces.Repositories;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IObservationAppService>().To<ObservationAppService>();
            kernel.Bind<ISelfEvaluationAppService>().To<SelfEvaluationAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IObservationService>().To<ObservationService>();
            kernel.Bind<ISelfEvaluationService>().To<SelfEvaluationService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IObservationRepository>().To<ObservationRepository>();
            kernel.Bind<ISelfEvaluationRepository>().To<SelfEvaluationRepository>();

            kernel.Bind<IFileSystem>().To<FileSystem>();
            kernel.Bind<IFileUploadService>().To<FileUploadService>();
            kernel.Bind<IFileUploadRepository>().To<FileUploadRepository>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAuthUserRepository>().To<AuthUserRepository>();
            kernel.Bind<IAuthUserService>().To<AuthUserService>();
            kernel.Bind<IAuthUserAppService>().To<AuthUserAppService>();

            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IEmployeeAppService>().To<EmployeeAppService>();
            kernel.Bind<IEmployeeService>().To<EmployeeService>();

            kernel.Bind<IPersonRepository>().To<PersonRepository>();

            kernel.Bind<IAnnotationTypeAppService>().To<AnnotationTypeAppService>();
            kernel.Bind<IAnnotationTypeRepository>().To<AnnotationTypeRepository>();
            kernel.Bind<IAnnotationTypeService>().To<AnnotationTypeService>();

            kernel.Bind<IEvaluationNotesAppService>().To<EvaluationNotesAppService>();

            kernel.Bind<IObserverService>().To<ObserverService>();
            kernel.Bind<IObserverRepository>().To<ObserverRepository>();

            kernel.Bind<IObservedService>().To<ObservedService>();
            kernel.Bind<IObservedRepository>().To<ObservedRepository>();

            kernel.Bind<IRapReportService>().To<RapReportService>();
            kernel.Bind<IRapReportRepository>().To<RapReportRepository>();
        }        
    }
}
