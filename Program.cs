using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class Program
    {
        static void Main(string[] args)
        {

            var oldCliente = new Cliente { Id = 1, Cnpj = "12345678", Nome = "Empresa A", Senha = "ABC1234" };
            var newCliente = new Cliente { Id = 1, Cnpj = "123456789", Nome = "Empresa B", Senha = "1234ABC" };

            Auditoria.AuditChanges(oldCliente, newCliente);

            Console.ReadKey();

        }
    }
}
