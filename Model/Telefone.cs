using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Telefone
    {
        [Display(Name = "ID Telefone")]
        public int IdTelefone { get; set; }

        [Display(Name = "Tipo de Telefone")]
        public string TipoTelefone { get; set; }

        [Display(Name = "DDD")]
        public string Ddd { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NumeroTel { get; set; }

        [Display(Name = "ID Cliente")]
        public int IdClienteFkTelefone { get; set; }
    }
}
