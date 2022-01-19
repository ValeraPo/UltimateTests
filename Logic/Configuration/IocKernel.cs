using Ninject;
using Ninject.Modules;

namespace Logic.Configuration
{
    public static class IocKernel
    {
        private static StandardKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Initialize(params INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);
        }
    }
}