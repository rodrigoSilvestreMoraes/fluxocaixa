using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace FluxoCaixa.Core.Domain.Models.Transacao
{
	public abstract class RegistroTransacaoBase
	{
		[JsonIgnore]
		public ObjectId Id { get; set; }
		public string Codigo
		{
			get
			{
				return Id.ToString();
			}
		}
		public string Descricao { get; set; }
		public DateTime DadaCadastro { get; set; } = DateTime.Now;
		public DateTime DataAtualizacao { get; set; } = DateTime.Now;
		public DateTime DataPagamento { get; set; }
		public bool EstaAgendado { get; protected set; }
		public StatusTransacao Status { get; protected set; } 
		public decimal Valor { get; set; }

		protected void ProcessarStatus()
		{
			if((DataPagamento.Date - DateTime.Now.Date).TotalDays > 0)
			{
				Status = StatusTransacao.EmAberto;
				EstaAgendado = true;
			}
		}
	}
}
