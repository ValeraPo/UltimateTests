using Data.Interfaces;
using Data.Maps;
using Logic.Interfaces;
using Ninject.Modules;

namespace Logic.Configuration
{
    public class ProjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            //Репозитории
            Bind<IRepository<AppointmentQuizze>>().To<Data.Repositories.AppointmentQuizRepo>().InSingletonScope();
            Bind<IRepository<Attempt>>().To<Data.Repositories.AttemptRepo>().InSingletonScope();
            Bind<IRepository<Feedback>>().To<Data.Repositories.FeedbackRepo>().InSingletonScope();
            Bind<IRepository<Group>>().To<Data.Repositories.GroupRepo>().InSingletonScope();
            Bind<IRepository<Quizze>>().To<Data.Repositories.QuizzeRepo>().InSingletonScope();
            Bind<IRepository<SetTag>>().To<Data.Repositories.SetTagRepo>().InSingletonScope();
            Bind<IRepository<User>>().To<Data.Repositories.UserRepo>().InSingletonScope();

            //Процессоры
            Bind<IUser>().To<Processes.User>().InSingletonScope();
            Bind<IAttempt>().To<Processes.Attempt>().InSingletonScope();
            Bind<IAppointmentQuizze>().To<Processes.AppointmentQuizze>().InSingletonScope();
            Bind<IFeedback>().To<Processes.Feedback>().InSingletonScope();
            Bind<IGroup>().To<Processes.Group>().InSingletonScope();
            Bind<IQuizze>().To<Processes.Quizze>().InSingletonScope();
            Bind<ISetTag>().To<Processes.SetTag>().InSingletonScope();
        }
    }
}