using backend.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace backend.Mdl
{
    public class Usuario : IdentityUser<long>, IModel
    {
        
    }
}
