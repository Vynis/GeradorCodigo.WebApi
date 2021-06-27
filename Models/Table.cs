using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorCodigo.WebApi.Models
{
    public class Table
    {
        public string Tabela { get; set; }
        public List<ColumnsTable> Colunas { get; set; } = new List<ColumnsTable>();
    }
}
