﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransAluraApiRestEstudo.Data.Dtos
{
    public class UpdateFimeDto
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
