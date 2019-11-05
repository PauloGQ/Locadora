using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Telefone
    {
        public int IdTelefone { get; set; }

        public int IdCliente { get; set; }

        public Enum Tipo { get; set; }

        public string NroTelefone { get; set; }
    }
}
