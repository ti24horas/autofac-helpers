namespace Autofac.Helpers
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Autofac.Builder;

    public static class AutofacExtensions
    {
        #region Public Methods and Operators

        public static IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration> UsingCustomLifetimeScope<T, TConcreateActivatorData, TStyleRegistration>(
            this IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration> service, ScopeResolver resolver, Scope scope)
        {
            var hook = resolver.Resolve(scope);
            hook.ChangeScope(service);
            return service;
        }

        public static IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration> UsingCustomLifetimeScope<T, TConcreateActivatorData, TStyleRegistration>(this IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration> service, ICustomScopeHook hook)
        {
            hook.ChangeScope(service);
            return service;
        }

        public static IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration> UsingCustomLifetimeScope<T, TConcreateActivatorData, TStyleRegistration>(
            this IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration> service, Scope scope, Func<Scope, IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration>, IRegistrationBuilder<T, TConcreateActivatorData, TStyleRegistration>> customRegistrationScope)
        {
            customRegistrationScope(scope, service);
            return service;
        }

        public static ContainerBuilder RegisterDecoratedTypes(this ContainerBuilder builder, ScopeResolver scopeResolver, params Assembly[] assemblies)
        {
            foreach (var type in assemblies.SelectMany(c => c.GetTypes()))
            {
                RegisterAsImplementedInterfaces(builder, type, scopeResolver);
                RegisterAsSelf(builder, type, scopeResolver);
            }

            return builder;
        }

        private static void RegisterAsImplementedInterfaces(ContainerBuilder builder, Type type, ScopeResolver scopeResolver)
        {
            var attr = type.GetCustomAttribute<ExportImplementedInterfaces>();
            if (attr == null)
            {
                return;
            }

            builder.RegisterType(type).AsImplementedInterfaces().UsingCustomLifetimeScope(scopeResolver, attr.Scope);
        }

        private static void RegisterAsSelf(ContainerBuilder builder, Type type, ScopeResolver resolver)
        {
            var attr = type.GetCustomAttribute<ExportAttribute>();

            if (attr == null)
            {
                return;
            }

            builder.RegisterType(type).AsSelf().UsingCustomLifetimeScope(resolver, attr.Scope);
        }

        #endregion
    }
}