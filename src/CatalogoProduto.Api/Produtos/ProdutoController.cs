using System;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoProduto.Domain.Entities;
using CatalogoProduto.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProduto.Api.Produtos
{
    [Route("produtos")]
    public class ProdutoController
        : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _service;

        public ProdutoController(IMapper pMapper
            , IProdutoService pService)
        {
            _mapper = pMapper;
            _service = pService;
        }

        [HttpGet("{pId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<ProdutoModel>> Get(int pId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProdutoAdicionarModel pModel)
        {
            var xItem = await _service.AdicionarAsync(_mapper.Map<Produto>(pModel));
            var xRetorno = CreatedAtAction(nameof(Get), new { pId = xItem.Id }, _mapper.Map<ProdutoModel>(xItem));
            return xRetorno;
        }
    }
}