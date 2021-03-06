using System.ComponentModel.DataAnnotations;

namespace APIShapeSkate.Data.Dtos
{
    public class CreateShapeDto
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Madeira { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório")]
        public int Tamanho { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório")]
        public float Valor { get; set; }
    }
}
