using Ninject;

namespace ToplantiTakip.Business.DependencyResolvers.Ninject
{
    class InstanceFactory<T>
    {
        public static T GetInstance()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
