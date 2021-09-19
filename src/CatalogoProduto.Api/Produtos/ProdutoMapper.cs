using AutoMapper;
using CatalogoProduto.Domain.Core.Entities;

namespace CatalogoProduto.Api.Produtos
{
    public class ProdutoMapper
        : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<ProdutoModel, Produto>()
                .ForMember(p => p.Id, p => p.MapFrom(pModel => pModel.Id))
                .ForMember(p => p.Nome, p => p.MapFrom(pModel => pModel.Nome))
                .ForMember(p => p.Valor, p => p.MapFrom(pModel => pModel.Valor))
                .ReverseMap()
                ;
        }
    }
}