using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleDeFinancasPessoais.Data;
using ControleDeFinancasPessoais.DTOs;
using ControleDeFinancasPessoais.Models;

namespace ControleDeFinancasPessoais.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/transacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacoes()
        {
            return await _context.Transacoes
                .Include(t => t.Categoria)
                .ToListAsync();
        }

        // POST: api/transacoes
        [HttpPost]
        public async Task<ActionResult<Transacao>> CreateTransacao(TransacaoCreateDto dto)
        {
            var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == dto.CategoriaId);
            if (!categoriaExiste)
            {
                return BadRequest("Categoria informada não existe.");
            }

            var transacao = new Transacao
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                Tipo = dto.Tipo,
                CategoriaId = dto.CategoriaId,
                Data = DateTime.UtcNow
            };

            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransacoes), new { id = transacao.Id }, transacao);
        }

        // GET: api/transacoes/resumo-saldo
        [HttpGet("resumo-saldo")]
        public async Task<IActionResult> GetResumoSaldo()
        {
            var receitas = await _context.Transacoes
                .Where(t => t.Tipo == EnumTipoTransacao.Receita)
                .SumAsync(t => t.Valor);

            var despesas = await _context.Transacoes
                .Where(t => t.Tipo == EnumTipoTransacao.Despesa)
                .SumAsync(t => t.Valor);

            var saldo = receitas - despesas;

            return Ok(new
            {
                TotalReceitas = receitas,
                TotalDespesas = despesas,
                SaldoFinal = saldo
            });
        }
    }
}