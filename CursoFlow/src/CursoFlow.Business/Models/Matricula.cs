using CursoFlow.Business.Enums;

namespace CursoFlow.Business.Models;

public class Matricula : Entity
{
    public Guid AlunoId { get; private set; }
    public Guid CursoId { get; private set; }
    public DateTime DataMatricula { get; private set; }
    public StatusMatricula Status { get; private set; }

    public Aluno? Aluno { get; private set; }
    public Curso? Curso { get; private set; }

    protected Matricula() { }

    public Matricula(Aluno aluno, Curso curso)
    {
        if (aluno is null || curso is null)
            throw new ArgumentException("Aluno e curso são obrigatórios.");

        AlunoId = aluno.Id;
        CursoId = curso.Id;
        Aluno = aluno;
        Curso = curso;
        DataMatricula = DateTime.UtcNow;
        Status = StatusMatricula.Pendente;
    }

    public void Confirmar()
    {
        if (Status != StatusMatricula.Pendente)
            throw new InvalidOperationException("A matrícula só pode ser confirmada se estiver pendente.");

        Status = StatusMatricula.Confirmada;
    }

    public void Iniciar()
    {
        if (Status != StatusMatricula.Confirmada)
            throw new InvalidOperationException("A matrícula só pode iniciar se estiver confirmada.");

        Status = StatusMatricula.EmAndamento;
    }

    public void Trancar()
    {
        if (Status != StatusMatricula.EmAndamento)
            throw new InvalidOperationException("Só é possível trancar uma matrícula em andamento.");

        Status = StatusMatricula.Trancada;
    }

    public void Concluir()
    {
        if (Status != StatusMatricula.EmAndamento)
            throw new InvalidOperationException("A matrícula precisa estar em andamento para ser concluída.");

        Status = StatusMatricula.Concluida;
    }

    public void Cancelar()
    {
        if (Status == StatusMatricula.Cancelada)
            throw new InvalidOperationException("A matrícula já foi cancelada.");

        Status = StatusMatricula.Cancelada;
    }
}
