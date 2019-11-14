using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Endereco
    {
        [Display(Name = "ID Endereço")]
        public int IdEndereco { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string IdClienteFkEndereco { get; set; }


    }
}
