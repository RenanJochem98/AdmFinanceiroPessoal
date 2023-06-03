using backend.Mdl;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet(Name = "Funcionario")]
        public Funcionario Get()
        {
            //return null;
            return new Funcionario()
            {
                Nome = "Renan",
                VinculoEmpregaticio = Enums.VinculoEmpregaticio.SocioAdministrador
            };
        }

    }
}
