using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Mdl
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; } 
        [MaxLength(100)]
        public string Nome { get; set; }
        public VinculoEmpregaticio VinculoEmpregaticio { get; set; }

    }
}
