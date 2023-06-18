namespace backend.Mdl
{
    public class ValorContaBancaria
    {
        public long Id { get; set; }
        public long ContaBancariaId { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
