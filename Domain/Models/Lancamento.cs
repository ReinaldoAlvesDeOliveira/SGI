using Domain.Models.Enums;
using Domain.ViewModels;
using SGI.Helper;

namespace Domain.Models
{
    public class Lancamento
    {
        public Lancamento() { }

        public Lancamento(LancamentoViewModel lancamento)
        {
            Descricao = lancamento.Descricao;
            DataLancamento = DateTime.Now;
            Valor = lancamento.Valor;
            TipoLacamento = lancamento.TipoLacamento;
            
        }
        public int Id { get; set; }    
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public ETipoLacamento TipoLacamento { get; set; }
        public int? IdMatriz { get; set; } 
        public Matriz Matriz { get; set; }
        public int? IdCongregracao { get; set; } 
        public Congregacao Congregracao { get; set; }
        public int? IdMenbro { get; set; }
        public Membro Membro { get; set; }

        public string TipoLancamentoFormat => TipoLacamento.GetDisplayName();
        public string DataLancamentoFormat => DataLancamento.ToString("dd/MM/yyyy");

        public void AtualizarDados(LancamentoViewModel lancamento)
        {
            Descricao = lancamento.Descricao;
            Valor = lancamento.Valor;
            TipoLacamento = lancamento.TipoLacamento;
        }




    }
}
