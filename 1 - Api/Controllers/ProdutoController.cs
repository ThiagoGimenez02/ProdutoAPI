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
            _produtoService = produtoService; 
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetTodosRegistros()
        {
            List<Produto> produtos = _produtoService.GetProdutos(); // Faz uma requisição da lista de produtos
            return Ok(produtos);
        }

        [HttpGet]
        [Route("GerarRelatorio")]
        public ActionResult<List<ProdutoResumo>> GerarRelatorio()
        {
            List<ProdutoResumo> produtos = _produtoService.GetProdutoResumos(); // Faz uma requisição da lista de produtos
            return Ok(produtos);                                                // agrupados pelo nome
        }

        [HttpPost]
        [Route("GerarBase")]
        public IActionResult GerarBase(int quantidade)  // Envia uma quantidade de produtos a serem criados
        {                                               
            _produtoService.GerarBase(quantidade);
            return Ok();
        }

        [HttpDelete]
        [Route("LimparBase")]
        public IActionResult LimparBase()
        {
            _produtoService.LimparBase();               // Envia uma requisição de limpar o banco 
            return NoContent();                         
        }
    }
}