using Domain.ViewModels;

namespace Domain.Models
{
    public class Matriz
    {
        public Matriz() { }
        public Matriz(MatrizViewModel matriz)
        {
            NomeMatriz = matriz.NomeMatriz;
            Cnpj = matriz.Cnpj;
            Telefone = matriz.Telefone;
            Email = matriz.Email;
            Endereco = new Endereco(matriz.Endereco);
        }
        public int Id { get; set; }
        public string NomeMatriz { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Congregacao> Congregracaoes { get; set; }
        public ICollection<Membro> Membros { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }

        public void AtualizarDados(MatrizAtualizarViewModel matriz)
        {
            NomeMatriz = matriz.NomeMatriz;
            Cnpj = matriz.Cnpj;
            Telefone = matriz.Telefone;
            Email = matriz.Email;
            Endereco.Cep = matriz.Endereco.Cep;
            Endereco.Rua = matriz.Endereco.Rua;
            Endereco.Numero = matriz.Endereco.Numero;
            Endereco.Complemento = matriz.Endereco.Complemento;
            Endereco.Bairro = matriz.Endereco.Bairro;
            Endereco.Cidade = matriz.Endereco.Cidade;
            Endereco.Estado = matriz.Endereco.Estado;
        }

    }
}
