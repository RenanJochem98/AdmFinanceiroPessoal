using System.ComponentModel.DataAnnotations;

namespace backend.ViewModel.Usuario
{
    public class UsuarioLoginRequestViewModel
    {
        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
