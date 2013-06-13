namespace Autofac.Helpers
{
    using System.Collections.Generic;

    public class ScopeResolver
    {
        private readonly IDictionary<Scope, ICustomScopeHook> scopes = new Dictionary<Scope, ICustomScopeHook>();

        public ScopeResolver()
        {
            lock (this.scopes)
            {
                if (this.scopes.Count > 0)
                {
                    return;
                }
            }
        }

        public void UseScope<T>(Scope scope) where T : ICustomScopeHook, new()
        {
            this.scopes[scope] = new T();
        }

        public ICustomScopeHook Resolve(Scope scope)
        {
            return this.scopes[scope];
        }
    }
}