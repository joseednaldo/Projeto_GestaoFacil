using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFacil.Models
{
    public class FuncionarioData
    {

        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string cpf { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }

        public string Celular { get; set; }
        public string TelResidencial { get; set; }

        public string Email { get; set; }
        public bool Ativo { get; set; }

    }
}
