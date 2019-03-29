using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper; //importando..
using Projeto.Presentation.Mappings; //importando..

namespace Projeto.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //executa o projeto
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //registrando o AutoMapper..
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToComponent>();
                cfg.AddProfile<EntityToViewModel>();
                cfg.AddProfile<ViewModelToEntity>();
            });
        }
    }
}
