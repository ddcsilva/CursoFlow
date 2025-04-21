namespace CursoFlow.Business.Models;

public class Endereco : Entity
{
    protected Endereco() { }

    public Endereco(string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado)
    {
        Atualizar(logradouro, numero, complemento, cep, bairro, cidade, estado);
    }

    public string Logradouro { get; private set; } = null!;
    public string Numero { get; private set; } = null!;
    public string Complemento { get; private set; } = null!;
    public string Cep { get; private set; } = null!;
    public string Bairro { get; private set; } = null!;
    public string Cidade { get; private set; } = null!;
    public string Estado { get; private set; } = null!;

    public Guid AlunoId { get; private set; }

    public Aluno? Aluno { get; private set; }

    public void Atualizar(string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado)
    {
        if (string.IsNullOrWhiteSpace(cep)) throw new ArgumentException("CEP inválido.");

        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Cep = cep;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
    }
}

