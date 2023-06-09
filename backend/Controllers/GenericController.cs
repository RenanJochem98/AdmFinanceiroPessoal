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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TModel? item = Repositorio.AsQueryable()
                .SingleOrDefault(i => i.Id.Equals(id));

            return item == null ?
                NotFound() :
                Ok(item);
        }

        [HttpGet()]
        public IActionResult Get()
        {
            //Como adicionar parametros para executar condições de busca
            return Ok(Repositorio.AsQueryable().ToList());
        }

        [HttpPost()]
        public IActionResult Create(TModel item)
        {
            Repositorio.Add(item);
            this.DataContext.SaveChanges();
            return Ok(item);
        }

        [HttpPut()]
        public IActionResult Put(TModel item)
        {
            //Como alterar apenas os campos enviados
            Repositorio.Update(item);
            DataContext.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TModel? item = Repositorio.AsQueryable()
               .SingleOrDefault(i => i.Id.Equals(id));
            if (item == null)
            {
                return NotFound();
            }

            Repositorio.Remove(item);
            DataContext.SaveChanges();
            return Ok();
        }
    }
}
