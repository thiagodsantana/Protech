using System.ComponentModel.DataAnnotations;

namespace ProtechTeste.Domain.Objects
{
    public class Experiencia
    {
        [Display(Name = "Tecnologia", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Tecnologia é obrigatório")]
        public string Tecnologia { get; set; }

        [Display(Name = "Tempo Experiência", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Tempo Experiência é obrigatório")]
        public int TempoExperiencia { get; set; }


        [Display(Name = "Detalhes Experiência", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Detalhes Experiência é obrigatório")]
        public string DetalheExperiencia { get; set; }
    }
}