using System.ComponentModel.DataAnnotations;

namespace APIShapeSkate.Data
{
    public class Shape
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo é obrigatório")]
        public string Madeira { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório")]
        public int Tamanho { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório")]
        public float Valor { get; set; }
    }
}
