using AutoMapper;
using backend.Data;
using backend.Interfaces;
using backend.Mdl;
using backend.ViewModel.Funcionario;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : GenericController<FuncionarioViewModelRequest, FuncionarioViewModelResponse, Funcionario>
    {
        public FuncionarioController(IMapper mapper) : base(mapper)
        {
        }

        public override DbSet<Funcionario> Repositorio
        {
            get
            {
                return this.DataContext.Funcionarios;
            }
        }

    }
}
