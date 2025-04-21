using CursoFlow.Business.Enums;

namespace CursoFlow.Business.Models;

public class Curso : Entity
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int CargaHoraria { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataCriacao { get; set; }
    public CategoriaCurso Categoria { get; set; }
    public bool Ativo { get; set; }

    // 1:N
    public IEnumerable<Matricula> Matriculas { get; set; }
}

