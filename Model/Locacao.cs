using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class Locacao
    {

        [Display(Name = "ID Locacao")]
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
        public string ValorLocacao { get; set; }
        [Display(Name = "Cliente")]
        public string Nome { get; set; }
        [Display(Name = "Funcionário")]
        public string NomeFuncionario { get; set; }


        [Display(Name = "Filme")]
        public string NomeFilme { get; set; }

    }
}
