using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService; // pega o contexto a ser usado
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetTodosRegistros()
        {
            List<Produto> produtos = _produtoService.GetProdutos(); // faz uma requisição da lista de produtos para o IProdutoService
            return Ok(produtos);
        }

        [HttpGet]
        [Route("GerarRelatorio")]
        public ActionResult<List<ProdutoResumo>> GerarRelatorio()
        {
            List<ProdutoResumo> produtos = _produtoService.GetProdutoResumos(); // faz uma requisição da lista de produtos
            return Ok(produtos);                                                // agrupados pelo nome para o IProdutoService
        }

        [HttpPost]
        [Route("GerarBase")]
        public IActionResult GerarBase(int quantidade)  // Envia uma quantidade de produtos a serem criados
        {                                               // pelo o IProdutoService
            _produtoService.GerarBase(quantidade);
            return Ok();
        }

        [HttpDelete]
        [Route("LimparBase")]
        public IActionResult LimparBase()
        {
            _produtoService.LimparBase();               // Envia uma requisição de limpar o banco pelo o IProdutoService
            return NoContent();                         
        }
    }
}