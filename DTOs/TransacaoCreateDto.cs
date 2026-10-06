using System.ComponentModel.DataAnnotations;
using GestaoDeFinancasPessoais.Models;

namespace GestaoDeFinancasPessoais.DTOs
{
    public class TransacaoCreateDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        public EnumTipoTransacao Tipo { get; set; }

        public int CategoriaId { get; set; }
    }
}