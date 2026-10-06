namespace GestaoDeFinancasPessoais.Models;

public class Transacao
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;
    public EnumTipoTransacao Tipo { get; set; }

    // Chave Estrangeira para Categoria
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}