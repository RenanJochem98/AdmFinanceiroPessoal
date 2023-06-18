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
        protected DbSet<TModel> repositorio;
        protected IMapper mapper;
        protected DataContext dataContext;

        public GenericController(IMapper mapper, DataContext dataContext)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
            this.repositorio = dataContext.Set<TModel>();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TModel? item = repositorio.AsQueryable()
                .SingleOrDefault(i => i.Id.Equals(id));

            return item == null ?
                NotFound() :
                Ok(mapper.Map<TViewModelResponse>(item));
        }

        [HttpGet()]
        public IActionResult Get()
        {
            //Como adicionar parametros para executar condições de busca?
            return Ok(mapper.Map<IEnumerable<TViewModelResponse>>(repositorio.AsQueryable().AsEnumerable()));
        }

        [HttpPost()]
        public virtual IActionResult Create(TViewModelRequest item)
        {
            TModel modelo = mapper.Map<TModel>(item);
            repositorio.Add(modelo);
            this.dataContext.SaveChanges();
            return Ok(mapper.Map<TViewModelResponse>(item));
        }

        [HttpPut()]
        public IActionResult Put(TModel item)
        {
            //Como alterar apenas os campos enviados
            TModel modelo = mapper.Map<TModel>(item);
            repositorio.Update(modelo);
            this.dataContext.SaveChanges();
            return Ok(mapper.Map<TViewModelResponse>(item));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TModel? item = repositorio.AsQueryable()
               .SingleOrDefault(i => i.Id.Equals(id));
            if (item == null)
            {
                return NotFound();
            }

            repositorio.Remove(item);
            dataContext.SaveChanges();
            return Ok();
        }
    }
}
