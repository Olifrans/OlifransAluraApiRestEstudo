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
        public FilmeController(FilmeContext filmeContext)
        {
            _filmeContext = filmeContext;
        }


        [HttpPost] //Criar recurso no sistema
        public IActionResult AdcionarFilme([FromBody] CreateFimeDto filmedto)  //Ajuste "CreateFimeDtos" para que o cliente não precise esta enviando o Id
        {
            Filme filme = new Filme //Criação de um objeto com um construtor implicito
            {
                Titulo = filmedto.Titulo,
                Genero = filmedto.Genero,
                Duracao = filmedto.Duracao,
                Diretor = filmedto.Diretor,
            };
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
                ReadmeFimeDto filmeDto = new ReadmeFimeDto //Criação de um objeto com um construtor implicito
                {
                    Titulo = filme.Titulo,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    Diretor = filme.Diretor,
                    Id = filme.Id,
                    HoraConsulta = DateTime.Now
                };
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
            filme.Titulo = filmeUpdateDto.Titulo;
            filme.Diretor = filmeUpdateDto.Diretor;
            filme.Genero = filmeUpdateDto.Genero;
            filme.Duracao = filmeUpdateDto.Duracao;
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
