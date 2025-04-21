namespace CursoFlow.Business.Models;

public class Matricula : Entity
{
    public Guid AlunoId { get; set; }
    public Guid CursoId { get; set; }
    public DateTime DataMatricula { get; set; }
    public string Status { get; set; }

    // Navegação
    public Aluno Aluno { get; set; }
    public Curso Curso { get; set; }
}

