using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtechTeste.Domain.Objects
{
    public class Funcionario
    {
        public int Id { get; set; }
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(120, ErrorMessage = "Máximo 120 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data Nascimento", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Data Nascimento é obrigatório")]        
        public string DataNascimento { get; set; }
        public List<Formacao> Formacao { get; set; }
        public int ExperienciaTotal { get; set; }
        public List<Experiencia> Experiencia { get; set; }
        public List<ExperienciaEmpresas> ExperienciaEmpresas { get; set; }


        //public Funcionario()
        //{
        //    this.Formacao = new List<Formacao>();
        //    this.Experiencia = new List<Experiencia>();
        //    this.ExperienciaEmpresas = new List<ExperienciaEmpresas>();
        //}
    }
}
