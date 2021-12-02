using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Models
{
    [Table("USUARIO_LIKE_PROJETO")]
    public class UsuarioLikeProjeto
    {
        [Column("ID"), Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public Usuario UsuarioLike { get; set; }
        [Column("ID_USUARIO_LIKE"), Required]
        [ForeignKey("ID_USUARIO_LIKE")]
        public int IdUsuarioLike { get; set; }
        //ProjetoLike & IdProjetoLike: um vínculo forte, pq ao mesmo tempo q vou pegar a Id, tb vou pegar o obj. - isso tb bloqueia um projeto de ser add caso ele não exista em Projeto
        public Projeto ProjetoLike { get; set; }
        [Column("ID_PROJETO_LIKE"), Required]
        [ForeignKey("ID_PROJETO_LIKE")]
        public  int IdProjetoLike { get; set; }

    }
}
