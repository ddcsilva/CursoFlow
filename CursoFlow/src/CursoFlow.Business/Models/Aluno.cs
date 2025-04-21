using CursoFlow.Business.Enums;

namespace CursoFlow.Business.Models;

public class Aluno : Entity
{
    private readonly List<Matricula> _matriculas = [];

    protected Aluno() { }

    public Aluno(string nome, string cpf, string email, DateTime dataNascimento, TipoAluno tipoAluno)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        DataNascimento = dataNascimento;
        TipoAluno = tipoAluno;
        Ativo = true;
    }

    public string Nome { get; private set; } = null!;
    public string Cpf { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public DateTime DataNascimento { get; private set; }
    public TipoAluno TipoAluno { get; private set; }
    public bool Ativo { get; private set; }

    public Endereco? Endereco { get; private set; }

    public IReadOnlyCollection<Matricula> Matriculas => _matriculas;

    public void AlterarDados(string nome, string email, TipoAluno tipoAluno)
    {
        Nome = nome;
        Email = email;
        TipoAluno = tipoAluno;
    }

    public void Ativar() => Ativo = true;
    public void Inativar() => Ativo = false;

    public void DefinirEndereco(Endereco endereco)
    {
        ArgumentNullException.ThrowIfNull(endereco);
        Endereco = endereco;
    }

    public void Matricular(Curso curso)
    {
        if (!Ativo) throw new InvalidOperationException("Aluno inativo não pode se matricular.");
        if (curso is null || !curso.Ativo) throw new InvalidOperationException("Curso inválido ou inativo.");

        var matricula = new Matricula(this, curso);
        _matriculas.Add(matricula);
    }
}
