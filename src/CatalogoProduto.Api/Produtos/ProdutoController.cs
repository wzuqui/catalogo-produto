using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoProduto.Domain.Core.Entities;
using CatalogoProduto.Domain.Core.Interfaces;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProdutoModel>>> Get()
        {
            var xLista = await _service.ListarAsync();
            var xRetorno = _mapper.Map<List<ProdutoModel>>(xLista);
            return Ok(xRetorno);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProdutoModel pModel)
        {
            var xItem = await _service.AdicionarAsync(_mapper.Map<Produto>(pModel));
            var xRetorno = CreatedAtAction(nameof(Get), new { pId = xItem.Id }, _mapper.Map<ProdutoModel>(xItem));
            return xRetorno;
        }
    }
}