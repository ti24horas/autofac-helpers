namespace Autofac.Helpers
{
    using System;

    public class ExportImplementedInterfaces : Attribute
    {
        public ExportImplementedInterfaces(Scope scope)
        {
            this.Scope = scope;
        }

        public Scope Scope { get; private set; }
    }
}