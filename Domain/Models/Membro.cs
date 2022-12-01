using Domain.Models.Enums;
using Domain.ViewModels;
using SGI.Helper;

namespace Domain.Models
{
    public class Membro
    {
        public Membro() { }

        public Membro(MembroViewModel membro)
        {
            Nome = membro.Nome;
            Cpf = membro.Cpf;
            DataNascimento = Convert.ToDateTime(membro.DataNascimento);
            Whatsapp = membro.Whatsapp;
            Telefone = membro.Telefone;
            Email = membro.Email;
            Pai = membro.Pai;
            Mae = membro.Mae;
            DataBatismoAgua = string.IsNullOrEmpty(membro.DataBatismoAgua) ? null : Convert.ToDateTime(membro.DataBatismoAgua);
            IdMatriz = membro.IdMatriz;
            EGenero = membro.Genero;
            IdCongregracao = membro.IdCongregracao;
            Endereco = new Endereco(membro.Endereco);
        }
       
        public int Id { get; set; }/// <summary>
        /// adicionar
        /// buscar por id
        /// </summary>
        public string Nome { get; set; }/// <summary>
        /// adicionar
        /// buscar por nome
        /// alterar nome
        /// </summary>
        public string Cpf { get; set; }/// <summary>
        /// adcionar
        /// alterar
        /// buscar por cfp
        /// </summary>
        public DateTime DataNascimento { get; set; }/// <summary>
        /// adicionar
        /// alterar
        /// </summary>
        public string Whatsapp { get; set; } /// <summary>
        /// alteração de tipo de variavel de int para string
        /// adicionar
        /// alterar
        /// 
        /// </summary>
        public string? Telefone { get; set; }/// <summary>
        /// adicionar
        /// alterar
        /// 
        /// </summary>
        public string? Email { get; set; }/// <summary>
        /// adcionar
        /// alterar
        /// </summary>
        public string? Pai { get; set; }/// <summary>
        /// adicionar
        /// alterar
        /// </summary>
        public string Mae { get; set; }/// <summary>

        /// adicionar
        /// alterar
        /// </summary>
        public DateTime? DataBatismoAgua { get; set; }/// <summary>

        /// adicionar
        /// alterar
        /// </summary>
        public EGenero EGenero { get; set; }

        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public int? IdMatriz { get; set; }
        public Matriz Matriz { get; set; }
        public int? IdCongregracao { get; set; }
        public Congregacao Congregracao { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }

        public string GeneroFormat => EGenero.GetDisplayName();
        public string DataBatismoAguaFormat => DataBatismoAgua?.ToString("dd/MM/yyyy");
        public string DataNascimentoFormat => DataNascimento.ToString("dd/MM/yyyy");

        public void AtualizarDados(MembroAtualizarViewModel membro)
        {
            Nome = membro.Nome;
            Cpf = membro.Cpf;
            DataNascimento = Convert.ToDateTime(membro.DataNascimento);
            Whatsapp = membro.Whattsapp;
            Telefone = membro.Telefone;
            Email = membro.Email;
            Pai = membro.Pai;
            Mae = membro.Mae;
            DataBatismoAgua = string.IsNullOrEmpty(membro.DataBatismoAgua) ? null : Convert.ToDateTime(membro.DataBatismoAgua);
            Endereco.Cep = membro.Endereco.Cep;
            Endereco.Rua = membro.Endereco.Rua;
            Endereco.Numero = membro.Endereco.Numero;
            Endereco.Complemento = membro.Endereco.Complemento;
            Endereco.Bairro = membro.Endereco.Bairro;
            Endereco.Cidade = membro.Endereco.Cidade;
            Endereco.Estado = membro.Endereco.Estado;
        }
    }
}