using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.DTO
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")] //substitui o {nº} pelo parâmetro (no caso, o parâmetro é a prop q vem abaixo. outro ex.: [Required(ErrorMessage = "O campo {0} e {1} são obrigatório", prop0, prop1)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //comparar os 2 campos de senha
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]  //[Compare("campo a ser comparado", ErrorMessage = "mensagem de erro")] (acima da prop a ser conferida c/ a outra)
        public string ConfirmaSenha { get; set; }

    }
}
