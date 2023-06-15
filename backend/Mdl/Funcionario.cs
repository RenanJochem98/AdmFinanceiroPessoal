using backend.Enums;
using backend.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace backend.Mdl
{
    public class Funcionario : IModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public VinculoEmpregaticio VinculoEmpregaticio { get; set; }

    }
}
