using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfnetMVC.Models
{
    [Authorize]
    public class Departamento
    {
        [Key]
        [Display(Name = "ID do Departamento")]
        private int id;
        [Required]
        [Display(Name = "Nome do Departamento")]
        private string nome;
        [Required]
        [MaxLength(200)]
        private string local;
        private ICollection<Funcionario>? funcionarios;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Local
        {
            get { return local; }
            set { local = value; }
        }
        public virtual ICollection<Funcionario>? Funcionarios // "Virtual" is appliable to properties.
        {
            get { return funcionarios; }
            set { funcionarios = value; }
        }
    }
}
