namespace Autofac.Helpers
{
    using Autofac.Builder;

    public class PerSession : ICustomScopeHook
    {
        public IRegistrationBuilder<TItem, TConcrete, TStyle> ChangeScope<TItem, TConcrete, TStyle>(IRegistrationBuilder<TItem, TConcrete, TStyle> service)
        {
            return service.InstancePerLifetimeScope();
        }
    }
}