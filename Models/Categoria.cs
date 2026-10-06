namespace GestaoDeFinancasPessoais.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        
        // Relacionamento 1:N
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}