using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class Cliente
    {
        [Audit("ID do Cliente", compare: false)]
        public int Id { get; set; }



        [Audit("CNPJ do Cliente", isSecondary: true)]
        public string Cnpj { get; set; }



        [Audit("Nome do Cliente", isPrimary: true)]
        public string Nome { get; set; }



        [Audit("Senha do Cliente", compare: false)]
        public string Senha { get; set; }
    }


    public class Empresa
    {
        [Audit("ID da Empresa", compare: false)]
        public int Id { get; set; }



        [Audit("Razão Social", isPrimary: true)]
        public string RazaoSocial { get; set; }



        [Audit("CNPJ da Empresa", isSecondary: true)]
        public string Cnpj { get; set; }



        [Audit("Telefone da Empresa")]
        public string Telefone { get; set; }
    }
}
