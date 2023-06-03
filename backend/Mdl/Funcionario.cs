using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Mdl
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public VinculoEmpregaticio VinculoEmpregaticio { get; set; }

    }
}
