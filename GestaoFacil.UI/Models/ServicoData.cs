using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFacil.Models
{
    public class ServicoData
    {
     
        public int ServicoId { get; set; }
        public string Descricao { get; set; }

        public decimal preco { get; set; }

        public bool IsDescontinuado { get; set; }

        public int DuracaoEmMinutos { get; set; }

        public float? Comissao { get; set; }

        public DateTime? DataCadastro { get; set; }
        public DateTime? DtAtualizacao { get; set; }

    }
}
