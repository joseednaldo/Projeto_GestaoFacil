using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFacil.Models
{
    public class ValeData
    {
        public int ValeId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int FuncionarioId { get; set; }
        public string Funcionario { get; set; }

    }
}
