using AutoMapper;
using backend.Data;
using backend.Mdl;
using backend.ViewModel.ContaBancaria;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class ContaBancariaController : GenericController<ContaBancariaViewModelRequest, ContaBancariaViewModelResponse, ContaBancaria>
    {
        public ContaBancariaController(IMapper mapper, DataContext dataContext) : base(mapper, dataContext)
        {
        }

        [HttpPost("/AddValorContaBancaria")]
        public virtual IActionResult Create(ValorContaBancaria item)
        {
            var conta = this.dataContext.ContasBancarias.First(u => u.Id == item.ContaBancariaId);
            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }

            this.dataContext.ValoresContaBancaria.Add(item);
            this.dataContext.SaveChanges();
            return Ok(item);
        }
    }
}
