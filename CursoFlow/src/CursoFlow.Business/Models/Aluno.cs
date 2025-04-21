using CursoFlow.Business.Enums;

namespace CursoFlow.Business.Models;

public class Aluno : Entity
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public TipoAluno TipoAluno { get; set; }
    public bool Ativo { get; set; }

    // 1:1
    public Endereco Endereco { get; set; }

    // 1:N
    public IEnumerable<Matricula> Matriculas { get; set; }
}
