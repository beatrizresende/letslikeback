using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Services
{
    public class ProjetoService : IProjetoService
    {
        public readonly LetsLikeContext _contexto;
        public readonly IUsuarioLikeProjetoService _usuarioLikeProjetoService;

        public ProjetoService(LetsLikeContext contexto, IUsuarioLikeProjetoService usuarioLikeProjetoService)
        {
            _contexto = contexto;
            _usuarioLikeProjetoService = usuarioLikeProjetoService;
        }

        public Projeto LikeProjeto(UsuarioLikeProjeto like)
        {
            //verificar se o projeto recebido existe
            //e sim, add +1 no like contador e chamar o SaveOrUpdate do Projeto, inserir a injeção de dependencia de ProjetoLikeUsuario e o SaveOrUpdate dele também passando o parametro like

            var projeto = _contexto.Projetos.Where(e => e.Id.Equals(like.IdProjetoLike)).FirstOrDefault();

            if (projeto != null)
            {
                projeto.LikeContador++;
                SaveOrUpdate(projeto);
                _usuarioLikeProjetoService.SaveOrUpdate(like);
            }

            return projeto;
        }

        public Projeto SaveOrUpdate(Projeto projeto)
        {
            // TODO primeira coisa a se fazer
            //vendo se o projeto está ligado a um usuário existente

            if (_contexto.Usuarios.Any(e => e.Id.Equals(projeto.IdUsuarioCadastro))) //o any faz a msm coisa que o where, mas retorna um booleano
            {
                // TODO
                var estado = projeto.Id == 0 ? EntityState.Added : EntityState.Modified; //se sim, verificamos se a Id do projeto é igual a 0. se sim, ele é marcado como uma adição. se não, ele é marcado como uma modificação
                _contexto.Entry(projeto).State = estado; //reatribui o estado do projeto
                _contexto.SaveChanges(); //salva as mudanças, que vai indentificar o estado do projeto e adicioná-lo (Add) ou atualizá-lo (Update)
                return projeto;
            }
            else
            {
                return null;
            }
        }
    }
}
