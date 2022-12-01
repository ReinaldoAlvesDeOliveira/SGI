using Domain.ViewModels;

namespace Domain.Models
{
    public class Congregacao
    {
        public Congregacao() { }
        public Congregacao (CongregacaoViewModel congregacao)
        {
            NomeCongregacao = congregacao.NomeCongregacao;
            Cnpj = congregacao.Cnpj;
            Telefone = congregacao.Telefone;
            Email = congregacao.Email;
            Endereco = new Endereco(congregacao.Endereco);
            IdMatriz = congregacao.IdMatriz;
        }
        public int Id { get; set; }
        public string NomeCongregacao { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public int IdMatriz { get; set; }
        public Matriz Matriz { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Membro> Membros { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }

        public void AtualizarDados(CongregacaoAtualizarViewModel congregacao)
        {
            NomeCongregacao = congregacao.NomeCongregacao;
            Cnpj = congregacao.Cnpj;
            Telefone = congregacao.Telefone;
            Email = congregacao.Email;
            Endereco.Cep = congregacao.Endereco.Cep;
            Endereco.Rua = congregacao.Endereco.Rua;
            Endereco.Numero = congregacao.Endereco.Numero;
            Endereco.Complemento = congregacao.Endereco.Complemento;
            Endereco.Bairro = congregacao.Endereco.Bairro;
            Endereco.Cidade = congregacao.Endereco.Cidade;
            Endereco.Estado = congregacao.Endereco.Estado;
        }

    }
}
