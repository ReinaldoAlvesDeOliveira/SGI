using Domain.ViewModels;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Endereco
    {
        public Endereco(){}

        public Endereco(EnderecoViewModel endereco)
        {
            Rua = endereco.Rua;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Pais = endereco.Pais;
            Estado = endereco.Estado;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Cep = endereco.Cep;
        }

        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        [JsonIgnore]
        public ICollection<Congregacao> Congregracoes { get; set; }
        [JsonIgnore]
        public ICollection<Matriz> Matrizes { get; set; }
        [JsonIgnore]
        public ICollection<Membro> Membros { get; set; }

        public void AtualizarDados(EnderecoViewModel endereco)
        {
            Rua = endereco.Rua;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Pais = endereco.Pais;
            Estado = endereco.Estado;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Cep = endereco.Cep;
        }
    }
}
