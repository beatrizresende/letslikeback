using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Services //vou trabalhar com os registros q quero criar, upar etc
{
    public class UsuarioService : IUsuarioService
    {
        public LetsLikeContext _contexto;
        public UsuarioService(LetsLikeContext contexto)
        {
            _contexto = contexto;
        }

        public IList<Usuario> FindAllUsuarios()
        {
            return _contexto.Usuarios.Include(x => x.Projeto)
                .ThenInclude(j => j.UsuarioCadastro)
                .ToList();
        }

        public Usuario SaveOrUpdate(Usuario usuario)
        {
            //mesmo método p/ salvar e upar o usuario

            //verificando se o user já existe p/ saber se ele será criado ou upado
            var existe = _contexto.Usuarios.Where(x => x.Id.Equals(usuario.Id)).FirstOrDefault();

            if(existe == null)
            {
                _contexto.Usuarios.Add(usuario);
            }
            else
            {
                existe.Nome = usuario.Nome;
                existe.Username = usuario.Username;
                existe.Senha = usuario.Senha;
                existe.Email = usuario.Email; //esses são os unicos campos pertencentes ao USUARIO. qualquer coisa n principal n pertencente a eles n deve estar na service
            }
            _contexto.SaveChanges();

            return usuario;
        }
    }
}
