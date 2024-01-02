namespace SoftwareArchitectureDesignAPI.Business.AutofacDependencies
{
    using System.Reflection;
    using Autofac;

    public class AutofacBusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();
        }
    }
}