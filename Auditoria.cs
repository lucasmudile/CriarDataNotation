using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class Auditoria
    {

        public static void AuditChanges<T>(T oldObject, T newObject)
        {
            ValidateAuditAttributes<T>();



            var type = typeof(T);
            var properties = type.GetProperties();



            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<AuditAttribute>();
                if (attribute != null)
                {
                    var oldValue = property.GetValue(oldObject);
                    var newValue = property.GetValue(newObject);



                    if (attribute.Compare && !Equals(oldValue, newValue))
                    {
                        Console.WriteLine($"{attribute.Description} - De: '{oldValue}' Para: '{newValue}'");
                    }
                }
            }
        }


        private static void ValidateAuditAttributes<T>()
        {
            var properties = typeof(T).GetProperties();
            var primaryCount = properties.Count(p => p.GetCustomAttribute<AuditAttribute>()?.IsPrimary == true);
            var secondaryCount = properties.Count(p => p.GetCustomAttribute<AuditAttribute>()?.IsSecondary == true);



            if (primaryCount != 1)
                throw new InvalidOperationException($"A classe {typeof(T).Name} deve ter exatamente uma propriedade primária.");
            if (secondaryCount > 1)
                throw new InvalidOperationException($"A classe {typeof(T).Name} não pode ter mais de uma propriedade secundária.");
        }
    }
}
