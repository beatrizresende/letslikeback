using AutoMapper;
using LetsLike.Data;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        //COMENTÁRIOS XML:

        // POST api/usuario
        /// <summary>
        /// Cria um usuário na base de dados conforme informado no corpo da requisição
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/usuario
        ///     { 
        ///        "nome": "Jaque Laurenti",
        ///        "email": "jaquelaurenti@gmail.com",
        ///        "username": "teste",
        ///        "senha": "odeiomeuchefe",
        ///        "confirmaSenha": "odeiomeuchefe"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Usuário que foi inserido na base</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response> 
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //qnd eu coloco a response aqui, possosó tratá-la no corpo
        public ActionResult<Usuario> Post([FromBody] UsuarioDto value)  //não posso deixar as infos do usuario expostas, então crio um DTO
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nome = value.Nome,
                Username = value.Username,
                Email = value.Email,
                Senha = value.Senha,
                //n preciso salvar a confirmação de senha, só preciso garantir no front q as senhas estejam iguais
            };

           var response = _usuarioService.SaveOrUpdate(usuario);

            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notfound = new NotFoundObjectResult(res);
                notfound.StatusCode = 400;
                notfound.Value = "Erro ao cadastrar o usuário";

                return NotFound(notfound);
            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var response = _usuarioService.FindAllUsuarios();
            if(response != null)
            {
                return Ok(response.Select(x => _mapper.Map<Usuario>(x)).ToList()); //mapper: mapeia todas as dependências que a entidade tem (traz n só os dados do usuario, mas dos projs. q ele deu like tb, por ex.)
            }
            else
            {
                return NotFound();
            }
        }
    }
}
