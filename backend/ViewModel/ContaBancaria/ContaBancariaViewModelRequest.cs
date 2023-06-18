using backend.Mdl;
using System.ComponentModel.DataAnnotations;

namespace backend.ViewModel.ContaBancaria
{
    public class ContaBancariaViewModelRequest
    {
        [Required]
        public string Nome { get; set; }

        public IEnumerable<ValorContaBancaria> ValoresConta { get; set; }

        [Required]
        public string IdUsuario { get; set; }
    }
}
