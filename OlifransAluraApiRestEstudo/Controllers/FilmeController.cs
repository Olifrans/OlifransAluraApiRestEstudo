using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlifransAluraApiRestEstudo.Data;
using OlifransAluraApiRestEstudo.Data.Dtos;
using OlifransAluraApiRestEstudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OlifransAluraApiRestEstudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly FilmeContext _filmeContext;
        private readonly IMapper _mapper;
        public FilmeController(FilmeContext filmeContext, IMapper mapper)
        {
            _filmeContext = filmeContext;
            _mapper = mapper;
        }


        [HttpPost] //Criar recurso no sistema
        public IActionResult AdcionarFilme([FromBody] CreateFimeDto filmeDto)  //Ajuste "CreateFimeDtos" para que o cliente não precise esta enviando o Id
        {
            Filme filme = _mapper.Map<Filme>(filmeDto); //Mapeamento usando AutoMapper.
            
            _filmeContext.Filmes.Add(filme);
            _filmeContext.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme); // Código de status(201)--> Ok - Retornando o status da requisição e onde o recurso foi criado no formato Json
        }


        [HttpGet] //Retorna recurso do sistema
        public IEnumerable<Filme> RecuperaFilme()
        {
            return _filmeContext.Filmes; // Código de status(201)--> Ok - Retornando o status da requisição e onde o recurso foi criado no formato Json
        }



        [HttpGet("{id}")] //Retorna recurso do sistema por ID
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadmeFimeDto filmeDto = _mapper.Map<ReadmeFimeDto>(filme); //Mapeamento usando AutoMapper.
                return Ok(filmeDto); //Código de status (200)--> Ok - Retornando uma lista de livros no formato Json
            }
            return NotFound(); //Código de status (404)-->not found
        }
        

        // PUT api/<FilmeController>/5
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFimeDto filmeUpdateDto)
        {
            
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                Ok(_filmeContext.Filmes); //Código de status (200)--> Ok - Retornando uma lista de livros no formato Json
            }
            _mapper.Map(filmeUpdateDto, filme); //Mapeamento usando AutoMapper.
            _filmeContext.SaveChanges();
            return NoContent(); //Código de status (204)-->nocontet retornar uma resposta 204 Sem Conteúdo para uma operação pós-operação.
        }


        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound(); //Código de status (404)-->not found
            }
            _filmeContext.Remove(filme);
            _filmeContext.SaveChanges();
            return NoContent(); //Código de status (204)-->nocontet retornar uma resposta 204 Sem Conteúdo para uma operação pós-operação.
        } 
    }
}
