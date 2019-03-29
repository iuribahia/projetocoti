using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper; //importando..
using Projeto.Presentation.Models; //importando..
using Projeto.Entities; //importando..

namespace Projeto.Presentation.Mappings
{
    public class EntityToViewModel : Profile
    {
        public EntityToViewModel()
        {
            //          DE   ->          PARA
            CreateMap<Estoque, EstoqueConsultaViewModel>();
            CreateMap<Estoque, EstoqueEdicaoViewModel>();

            CreateMap<Produto, ProdutoConsultaViewModel>()
                    .AfterMap((src, dest) => dest.NomeEstoque = src.Estoque.Nome);
        }
    }
}