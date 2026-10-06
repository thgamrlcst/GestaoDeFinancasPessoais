using ControleDeFinancasPessoais.Models;

namespace ControleDeFinancasPessoais.DTOs
{
    public class TransacaoResponseDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } = string.Empty; // Retorna em texto (ex: "Receita", "Despesa")
        
        // Retorna apenas as informações simplificadas da categoria
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; } = string.Empty;
    }
}