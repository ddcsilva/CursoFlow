using CursoFlow.Business.Enums;

namespace CursoFlow.Business.Models;

public class Curso : Entity
{
    private readonly List<Matricula> _matriculas = new();

    public string Nome { get; private set; } = null!;
    public string Descricao { get; private set; } = null!;
    public int CargaHoraria { get; private set; }
    public decimal Preco { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public CategoriaCurso Categoria { get; private set; }
    public bool Ativo { get; private set; }

    public IReadOnlyCollection<Matricula> Matriculas => _matriculas;

    protected Curso() { }

    public Curso(string nome, string descricao, int cargaHoraria, decimal preco, CategoriaCurso categoria)
    {
        Nome = nome;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        Preco = preco;
        Categoria = categoria;
        DataCriacao = DateTime.UtcNow;
        Ativo = true;
    }

    public void AlterarDados(string nome, string descricao, int cargaHoraria, decimal preco)
    {
        Nome = nome;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        Preco = preco;
    }

    public void Ativar() => Ativo = true;
    public void Inativar() => Ativo = false;
}
