namespace Autofac.Helpers
{
    using Autofac.Builder;

    public class TransientScope : ICustomScopeHook
    {
        public IRegistrationBuilder<TItem, TConcrete, TStyle> ChangeScope<TItem, TConcrete, TStyle>(
            IRegistrationBuilder<TItem, TConcrete, TStyle> service)
        {
            return service.InstancePerDependency();
        }
    }
}