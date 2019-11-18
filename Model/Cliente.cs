using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Cliente
    {
        [Display(Name = "ID Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string Email { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }

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

        public int IdClienteFkEndereco { get; set; }



    }


}
