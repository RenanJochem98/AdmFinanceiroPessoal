using backend.Data;
using backend.Interfaces;
using backend.Mdl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : GenericController<Funcionario>
    {
        public override DbSet<Funcionario> Repositorio
        {
            get
            {
                return this.DataContext.Funcionarios;
            }
        }

    }
}
