using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using System.Web.Mvc;

namespace Projeto.Presentation.Mappings
{
    public class EntityToComponent : Profile
    {
        //construtor -> ctor + 2x[tab]
        public EntityToComponent()
        {
            CreateMap<Estoque, SelectListItem>()
                .AfterMap((src, dest)
                    => dest.Value = src.IdEstoque.ToString())
                .AfterMap((src, dest)
                    => dest.Text = src.Nome);                
        }
    }

    
}