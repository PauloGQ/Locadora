using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class Funcionario
    {
        [Display(Name = "ID Funcionário")]
        public int IdFuncionario { get; set; }

        
        [Display(Name = "Nome")]
        public string NomeFuncionario { get; set; }

        [Display(Name = "Email Funcionário")]
        public string EmailFuncionario { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
