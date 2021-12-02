using AutoMapper;
using LetsLike.DTO;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] (implementar)
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly IMapper _mapper;

        public ProjetoController(IProjetoService projetoService, IMapper mapper )
        {
            _projetoService = projetoService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //qnd eu coloco a response aqui, possosó tratá-la no corpo
        public ActionResult<ProjetoDto> Post([FromBody] ProjetoDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = new Projeto
            {
                Nome = value.Nome,
                URL = value.URL,
                Imagem = value.Imagem,
                IdUsuarioCadastro = value.IdUsuarioCadastro,
                LikeContador = 0, //o projeto está sendo inserido, então o contador pode começar em 0. se ele estivesse sendo atualizado, n poderia ser
            };  //criando um model e transferindo os dados de value pq o método de adição de projeto recebe um Projeto, não um ProjetoDto

            var salvarProjeto = _projetoService.SaveOrUpdate(model);

            if (salvarProjeto != null)
            {
                object res = null;
                ObjectResult x = new ObjectResult(res);
                x.StatusCode = 201;
                // TODO verificar como retornar o objeto que foi salvo com o status code correto.
                x.Value = salvarProjeto;
                return Ok(res);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notfound = new NotFoundObjectResult(res);
                notfound.StatusCode = 400;
                notfound.Value = "Erro ao cadastrar o Projeto";

                return NotFound(notfound);
            }

        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjetoDto> Patch([FromBody] UsuarioLikeProjetoDto like)
        {
            // TODO inserir o LIKEDOPROJETO 
            // quando ele disparar o método de LIKE que deverá ser construido
            // dentro da service de projeto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new UsuarioLikeProjeto()
            {
                IdProjetoLike = like.IdProjetoLike,
                IdUsuarioLike = like.IdUsuarioLike
            };

            var salvarLike = _projetoService.LikeProjeto(model);

            ObjectResult res = new ObjectResult(null);
            res.StatusCode = 201;
            // TODO verificar como retornar o objeto que foi salvo com o status code correto.
            res.Value = salvarLike;
            return Ok(res);
        }
    }
}
