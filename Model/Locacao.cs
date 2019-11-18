using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Model
{
    class Locacao
    {

        [Display(Name = "ID Endereço")]
        public int IdLocacao { get; set; }

        [Display(Name = "ID Cliente")]
        public int IdClienteFkLocacao { get; set; }

        [Display(Name = "ID Filme")]
        public int IdFilmeFkLocacao { get; set; }

        [Display(Name = "ID Funcionario")]
        public int IdFuncionarioFkLocacao { get; set; }

        [Display(Name = "Data da Locação")]
        public DateTime DataLocacao { get; set; }

        [Display(Name = "Data da Entrega")]
        public DateTime DataEntrega { get; set; }

        [Display(Name = "Valor")]
        public string Valorlocacao { get; set; }


    }
}
