using Microsoft.AspNetCore.Identity;

namespace backend.ViewModel
{
    public class UsuarioLoginResponseViewModel
    {
        public UsuarioResponseViewModel Usuario { get; set; }
        public string Token { get; set; }  
    }
}
