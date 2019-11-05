using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Endereco
    {

        public int IdEndereco { get; set; }

        public int Id_Endereco { get; set; }

        public string EnderecoLocal { get; set; }
        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
