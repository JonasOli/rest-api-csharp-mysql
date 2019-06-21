using System.ComponentModel.DataAnnotations;

namespace ex6.Models
{
    public class Pessoa
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string RG { get; set; }
        [Required]
        public string NomePai { get; set; }
        [Required]
        public string Escolaridade { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DataNascimento { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string NomeMae { get; set; }
        [Required]
        public string Profissao { get; set; }
        [Required]
        public string Celular { get; set; }
    }
}