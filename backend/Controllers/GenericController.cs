using backend.Data;
using backend.Interfaces;
using backend.Mdl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class GenericController<TModel> : Controller where TModel : class, IModel
    {
        public DataContext DataContext { get; set; } = new DataContext();
        public abstract DbSet<TModel> Repositorio { get; }

        [HttpGet("id:{{int}}")]
        public IActionResult Get(int id)
        {
            TModel? func = Repositorio.AsQueryable()
                .SingleOrDefault(i => i.Id.Equals(id));

            return func == null ?
                NotFound() :
                Ok(func);
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(Repositorio.AsQueryable().ToList());
        }

        [HttpPost()]
        public IActionResult Create(TModel item)
        {
            using (var db = new DataContext())
            {
                Repositorio.Add(item);
                db.SaveChanges();
                return Ok(item);
            }
        }
    }
}
