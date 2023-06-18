using Microsoft.AspNetCore.Identity;

namespace backend.ViewModel.Usuario
{
    public class UsuarioLoginResponseViewModel
    {
        public UsuarioResponseViewModel Usuario { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
