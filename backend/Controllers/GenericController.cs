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
using System.Threading;

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
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            TModel? item = await repositorio.AsQueryable()
                .SingleOrDefaultAsync(i => i.Id.Equals(id), cancellationToken);

            return item == null ?
                NotFound() :
                Ok(mapper.Map<TViewModelResponse>(item));
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            //Como adicionar parametros para executar condições de busca?
            return Ok(mapper.Map<IEnumerable<TViewModelResponse>>(repositorio.AsAsyncEnumerable()));
        }

        [HttpPost()]
        public virtual async Task<IActionResult> Create(TViewModelRequest item, CancellationToken cancellationToken = default)
        {
            TModel modelo = mapper.Map<TModel>(item);
            await repositorio.AddAsync(modelo, cancellationToken);
            await this.dataContext.SaveChangesAsync(cancellationToken);
            return Ok(mapper.Map<TViewModelResponse>(modelo));
        }

        [HttpPut()]
        public async Task<IActionResult> Put(TModel item, CancellationToken cancellationToken = default)
        {
            //Como alterar apenas os campos enviados
            TModel modelo = mapper.Map<TModel>(item);
            repositorio.Update(modelo);
            await this.dataContext.SaveChangesAsync(cancellationToken);
            return Ok(mapper.Map<TViewModelResponse>(modelo));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            TModel? item = await repositorio.AsQueryable()
               .SingleOrDefaultAsync(i => i.Id.Equals(id), cancellationToken);
            if (item == null)
            {
                return NotFound();
            }

            repositorio.Remove(item);
            await dataContext.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
