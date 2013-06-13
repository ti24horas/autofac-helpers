namespace Autofac.Helpers
{
    using System;

    public class ExportAttribute : Attribute
    {
        public ExportAttribute(Scope scope)
        {
            this.Scope = scope;
        }

        public Scope Scope { get; private set; }
    }
}