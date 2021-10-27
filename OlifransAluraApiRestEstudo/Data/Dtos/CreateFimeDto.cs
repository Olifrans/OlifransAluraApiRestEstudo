using System;
using System.ComponentModel.DataAnnotations;

namespace OlifransAluraApiRestEstudo.Data.Dtos
{
    public class CreateFimeDto
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório")] ////Validação eficiente sem sobrecarregar a controller
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O nome do diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O genero não pode passar de trinta caracteres")]
        public string Genero { get; set; }

        //[Required(ErrorMessage = "O tempo de duração é obrigatório")]
        [Range(5, 120, ErrorMessage = "O tempo de duração é de no minimo 1 e no maximo 5600 minutos")] ////Validação eficiente sem sobrecarregar tempo de exibição do filme
        public string Duracao { get; set; }
    }
}