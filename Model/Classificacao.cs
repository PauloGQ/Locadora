using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Classificacao
    {
        [Display(Name = "ID Classificação")]
        public int IdClassificacao { get; set; }

        [Display(Name = "Classificação Indicativa")]
        public string Classifica{ get; set; }



    }
}
