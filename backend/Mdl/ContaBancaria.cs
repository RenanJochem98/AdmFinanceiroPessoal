using backend.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace backend.Mdl
{
    public class ContaBancaria : IModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<ValorContaBancaria> ValoresConta { get; set; }

        public string IdUsuario { get; set; }

    }
}
