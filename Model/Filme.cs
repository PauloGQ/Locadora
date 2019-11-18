using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Filme
    {
        [Display(Name = "ID Filme")]
        public int IdFilme { get; set; }

        [Display(Name = "Nome")]
        public string NomeFilme { get; set; }

        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }

        [Display(Name = "Duração do Filme")]
        public string TempoDuracao { get; set; }

        [Display(Name = "Ano")]
        public string Ano { get; set; }

        [Display(Name = "ID Classificação")]
        public int IdClassificacaoFkFilme { get; set; }

        [Display(Name = "ID Gênero")]
        public int IdGeneroFkFilme { get; set; }

        public Byte[]  Imagem { get; set; }
        public byte[] Cartaz { get; set; }

        [Display(Name = "ID Genero")]
        public int IdGenero { get; set; }

        [Display(Name = "Gênero")]
        public string GeneroFilme { get; set; }

        [Display(Name = "ID Classificação")]
        public int IdClassificacao { get; set; }
        [Display(Name = "Classificação indicadiva")]
        public string Classifica { get; set; }

    }
}
