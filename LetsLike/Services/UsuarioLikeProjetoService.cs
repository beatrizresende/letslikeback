using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Services
{
    public class UsuarioLikeProjetoService : IUsuarioLikeProjetoService
    {
        public LetsLikeContext _contexto;
        public UsuarioLikeProjetoService(LetsLikeContext contexto)
        {
            _contexto = contexto;
        }

        public UsuarioLikeProjeto SaveOrUpdate(UsuarioLikeProjeto like)
        {
            var projeto = _contexto.Projetos.Where(x => x.Id == like.IdProjetoLike).FirstOrDefault();
            var usuario = _contexto.Usuarios.Where(x => x.Id == like.IdUsuarioLike).FirstOrDefault();

            if (projeto != null && usuario != null)
            {
                if (!_contexto.UsuariosLikeProjetos.Any(x => x.IdProjetoLike == projeto.Id && x.IdUsuarioLike == usuario.Id))
                {
                    like.ProjetoLike = projeto;
                    like.UsuarioLike = usuario;

                    _contexto.Add(like);
                    _contexto.SaveChanges();

                    return like;
                }
                else
                {
                    _contexto.Remove(like);
                    _contexto.SaveChanges();

                    return like;
                }
            }
            else
            {
                throw new FileNotFoundException(message: "Usuário e/ou projeto não encontrado(s)");
            }
        }
    }
}
