namespace Autofac.Helpers
{
    using Autofac.Builder;

    public interface ICustomScopeHook
    {
        #region Public Methods and Operators

        IRegistrationBuilder<TItem, TConcrete, TStyle> ChangeScope<TItem, TConcrete, TStyle>(IRegistrationBuilder<TItem, TConcrete, TStyle> service);

        #endregion
    }
}