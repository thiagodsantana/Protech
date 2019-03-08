using System;
using System.ComponentModel.DataAnnotations;

namespace ProtechTeste.Domain.Objects
{
    public class Formacao
    {
        [Display(Name = "Curso", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Curso é obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Curso { get; set; }

        [Display(Name = "Situação", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Situação é obrigatório")]
        public string Status { get; set; }

        [Display(Name = "Data Conclusão", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Data Conclusão é obrigatório")]
        public string DataConclusao { get; set; }
    }
}