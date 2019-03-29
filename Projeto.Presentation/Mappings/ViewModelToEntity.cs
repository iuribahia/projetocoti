using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper; //importando
using Projeto.Presentation.Models; //importando
using Projeto.Entities; //importando

namespace Projeto.Presentation.Mappings
{
    public class ViewModelToEntity : Profile
    {
        //construtor
        public ViewModelToEntity()
        {
            //registrando..    ORIGEM      ->   DESTINO
            CreateMap<EstoqueCadastroViewModel, Estoque>();
            CreateMap<EstoqueEdicaoViewModel, Estoque>();
            CreateMap<ProdutoCadastroViewModel, Produto>();
        }
    }
}