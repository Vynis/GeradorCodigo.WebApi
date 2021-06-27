using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorCodigo.WebApi.Models
{
    public class ColumnsTable
    {
        public string Field { get; set; }
        public string Type { get; set; }
        public string Null { get; set; }
        public string Key { get; set; }
        public string Extra { get; set; }
    }

}
