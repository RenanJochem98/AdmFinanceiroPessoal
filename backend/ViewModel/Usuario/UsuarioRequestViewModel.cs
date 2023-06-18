using System.ComponentModel.DataAnnotations;

namespace backend.ViewModel.Usuario
{
    public class UsuarioRequestViewModel
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //[EmailAddress]
        //public string EmailConfirmacao { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string SenhaConfirmacao { get; set; }
    }
}
