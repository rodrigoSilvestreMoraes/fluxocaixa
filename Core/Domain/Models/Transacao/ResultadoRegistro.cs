namespace FluxoCaixa.Core.Domain.Models.Transacao
{
	public class ResultadoRegistro<T>
	{
		public T Data { get; set; }
		public bool Erro { get; set; } = true;
		public List<string> Erros { get; set; } =  new List<string>();
	}
}
