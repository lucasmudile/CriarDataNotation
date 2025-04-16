using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AuditAttribute : Attribute
    {
        public string Description { get; }
        public bool IsPrimary { get; }
        public bool IsSecondary { get; }
        public bool Compare { get; }

        public AuditAttribute(string description, bool isPrimary = false, bool isSecondary = false, bool compare = true)
        {
            Description = description;
            IsPrimary = isPrimary;
            IsSecondary = isSecondary;
            Compare = compare;
        }
    }
}
