using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfnetMVC.Models
{
    [Authorize]
    public class Funcionario
    {
        [Key, Display(Name = "ID do Funcionário"), MaxLength(50)]
        private int id;
        [Required]
        [Display(Name = "Nome")]
        private string nome;
        [MaxLength(200)]
        private string endereco;
        [Required]
        private string email;
        [Required]
        [Display(Name = "Data de Nascimento")]
        private DateOnly dataNascimento;
        [Required]
        private int idDepartamento;
        [ForeignKey("idDepartamento")]
        private Departamento? departamento;

        public int Id {
            get { return id; } 
            set { id = value; } 
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateOnly DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        public virtual Departamento? Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
    }
}
