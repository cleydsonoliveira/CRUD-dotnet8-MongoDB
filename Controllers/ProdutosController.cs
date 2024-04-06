using ApiProdutosMongodb.Models;
using ApiProdutosMongodb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutosMongodb.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<ActionResult<Produto>> GetAll()
        {
            var prod = await _produtoService.GetProdutos();
            if (prod != null)
            {
                return Ok(prod);
            }
            return BadRequest("Não foi localizado nenhum produto em sua base de dados");
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Produto>> GetOne([FromRoute] string id)
        {
            var prod = await _produtoService.GetProduto(id);
            if (prod != null)
            {
                return Ok(prod);
            }
            return BadRequest($"Não foi localizado nenhum produto com o id: {id}");
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> NewPorduct(Produto newProduto)
        {
            await _produtoService.CreateProduto(newProduto);
            return Ok(newProduto);
        }
    }
}
