using AutoMapper;
using backend.Data;
using backend.Interfaces;
using backend.Mdl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public abstract class GenericController<TViewModelRequest, TViewModelResponse, TModel> : Controller where TModel : class, IModel
    {
        public DataContext DataContext { get; set; } = new DataContext();
        public abstract DbSet<TModel> Repositorio { get; }
        public IMapper mapper;

        public GenericController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TModel? item = Repositorio.AsQueryable()
                .SingleOrDefault(i => i.Id.Equals(id));

            return item == null ?
                NotFound() :
                Ok(mapper.Map<TViewModelResponse>(item));
        }

        [HttpGet()]
        public IActionResult Get()
        {
            //Como adicionar parametros para executar condições de busca?
            return Ok(mapper.Map<IEnumerable<TViewModelResponse>>(Repositorio.AsQueryable().AsEnumerable()));
        }

        [HttpPost()]
        public virtual IActionResult Create(TViewModelRequest item)
        {
            TModel modelo = mapper.Map<TModel>(item);
            Repositorio.Add(modelo);
            this.DataContext.SaveChanges();
            return Ok(mapper.Map<TViewModelResponse>(item));
        }

        [HttpPut()]
        public IActionResult Put(TModel item)
        {
            //Como alterar apenas os campos enviados
            TModel modelo = mapper.Map<TModel>(item);
            Repositorio.Update(modelo);
            this.DataContext.SaveChanges();
            return Ok(mapper.Map<TViewModelResponse>(item));
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
