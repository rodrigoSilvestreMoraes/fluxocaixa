namespace FluxoCaixa.Core.Domain.Models.Relatorio
{
    public class SaldoCaixa
    {
        public SaldoCaixa(DateTime dataInicial, DateTime dataFinal)
        {
            Periodo.DataInicial = dataInicial;
            Periodo.DataFinal = dataFinal;
        }
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo
        {
            get
            {
                return TotalReceitas - TotalDespesas;
            }
        }
        public PeriodoRelatorio Periodo { get; set; } = new PeriodoRelatorio();
    }

    public class PeriodoRelatorio
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
