using System;
using System.ComponentModel.DataAnnotations;

namespace ProtechTeste.Domain.Objects
{
    public class ExperienciaEmpresas
    {

        [Display(Name = "Empresa", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Empresa é obrigatório")]
        public string Empresa { get; set; }


        [Display(Name = "Cargo", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Cargo é obrigatório")]
        public string Cargo { get; set; }


        [Display(Name = "Data Início", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Data Início é obrigatório")]
        public string DataInicio { get; set; }


        [Display(Name = "Data Fim", AutoGenerateFilter = false)]        
        public string DataFim { get; set; }


        [Display(Name = "Detalhes Experiência", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Detalhes Experiência é obrigatório")]
        public string DetalheExperiencia { get; set; }        
    }
}