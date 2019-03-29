using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.Business;
using Projeto.Presentation.Models;
using AutoMapper;

namespace Projeto.Presentation.Controllers
{
    public class ProdutoController : Controller
    {
        //atributo
        private readonly ProdutoBusiness business;

        //construtor [ctor] + 2x[tab]
        public ProdutoController()
        {
            business = new ProdutoBusiness();
        }

        // GET: Produto/Cadastro
        public ActionResult Cadastro()
        {
            ProdutoCadastroViewModel model = null;

            try
            {
                model = CarregarDropDownListsParaCadastro();
            }
            catch(Exception e)
            {
                ViewData["Mensagem"] = e.Message;
            }

            return View(model);
        }        

        // GET: Produto/Consulta
        public ActionResult Consulta()
        {
            //declarando uma lista da viewmodel
            var model = new List<ProdutoConsultaViewModel>();

            try
            {
                model = Mapper.Map<List<ProdutoConsultaViewModel>>(business.ObterTodos());
            }
            catch (Exception e)
            {
                ViewData["Mensagem"] = e.Message;
            }

            //enviando a model para a view..
            return View(model);
        }

        //POST: Produto/CadastrarProduto
        [HttpPost]
        public ActionResult CadastrarProduto(ProdutoCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var produto = Mapper.Map<Produto>(model);
                    business.Cadastrar(produto);

                    ViewData["Mensagem"] = "Produto cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch(Exception e)
                {
                    ViewData["Mensagem"] = e.Message;
                }
            }
                       
            try
            {
                //recarregar a model com o dropdownlist
                model = CarregarDropDownListsParaCadastro();
            }
            catch (Exception e)
            {
                ViewData["Mensagem"] = e.Message;
            }

            return View("Cadastro", model);
        }

        //Método auxiliar..
        private static ProdutoCadastroViewModel CarregarDropDownListsParaCadastro()
        {
            var model = new ProdutoCadastroViewModel();

            var estoqueBusiness = new EstoqueBusiness();
            model.Estoques = Mapper.Map<List<SelectListItem>>
                                    (estoqueBusiness.ObterTodos()
                                        .OrderBy(e => e.Nome));
            
            return model;
        }
    }
}