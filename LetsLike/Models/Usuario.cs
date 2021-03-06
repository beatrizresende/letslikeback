using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Column("ID"), Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("NOME"), Required]
        public string Nome { get; set; }
        [Column("EMAIL"), Required]
        public string Email { get; set; }
        [Column("URSERNAME"), Required]
        public string Username { get; set; }
        [Column("SENHA"), Required]
        public string Senha { get; set; }
        //vínculo do Usuario com o Projeto - virtual pq o usuario pode ou não ter projeto, então essa lista pode ou não existir
        public virtual ICollection<Projeto> Projeto { get; set; }
        public virtual ICollection<UsuarioLikeProjeto> UsuarioLikeProjeto { get; set; }
    }
}
