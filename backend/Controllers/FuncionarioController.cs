﻿using backend.Mdl;
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
            using(var db = new Data.DataContext())
            {
                Funcionario func = db.Funcionarios.AsQueryable()
                    .Where(f => f.VinculoEmpregaticio == Enums.VinculoEmpregaticio.SocioAdministrador)
                    .First();
                return func;
            }
        }


        //[HttpPost(Name = "Funcionario")]
        //public Funcionario Create()
        //{
        //    //return null;
        //    return new Funcionario()
        //    {
        //        Nome = "Renan",
        //        VinculoEmpregaticio = Enums.VinculoEmpregaticio.SocioAdministrador
        //    };
        //}

    }
}
