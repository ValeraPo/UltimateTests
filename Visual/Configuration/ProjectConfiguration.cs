using Data.Interfaces;
using Data.Maps;
using Logic.Interfaces;
using Ninject.Modules;

namespace Visual.Configuration
{
    public class ProjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            //Репозитории
            Bind<IRepository<AppointmentQuizze>>().To<Data.Repositories.AppointmentQuizze>().InSingletonScope();
            Bind<IRepository<Attempt>>().To<Data.Repositories.Attempt>().InSingletonScope();
            Bind<IRepository<Feedback>>().To<Data.Repositories.Feedback>().InSingletonScope();
            Bind<IRepository<Group>>().To<Data.Repositories.Group>().InSingletonScope();
            Bind<IRepository<Quizze>>().To<Data.Repositories.Quizze>().InSingletonScope();
            Bind<IRepository<SetTag>>().To<Data.Repositories.SetTag>().InSingletonScope();
            Bind<IRepository<User>>().To<Data.Repositories.User>().InSingletonScope();
            
            //Процессоры
            Bind<IUser>().To<Logic.Processes.User>().InSingletonScope();
            Bind<IAttempt>().To<Logic.Processes.Attempt>().InSingletonScope();
            Bind<IAppointmentQuizze>().To<Logic.Processes.AppointmentQuizze>().InSingletonScope();
            Bind<IFeedback>().To<Logic.Processes.Feedback>().InSingletonScope();
            Bind<IGroup>().To<Logic.Processes.Group>().InSingletonScope();
            Bind<IQuizze>().To<Logic.Processes.Quizze>().InSingletonScope();
            Bind<ISetTag>().To<Logic.Processes.SetTag>().InSingletonScope();
        }
    }
}