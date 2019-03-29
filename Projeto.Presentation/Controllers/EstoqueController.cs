using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Entities; //importando
using Projeto.Business; //importando
using AutoMapper; //importando

namespace Projeto.Presentation.Controllers
{
    public class EstoqueController : Controller
    {
        //atributo
        private readonly EstoqueBusiness business;

        //construtor -> ctor + 2x[tab]
        public EstoqueController()
        {
            //inicializando o atributo..
            business = new EstoqueBusiness();
        }

        // GET: Estoque/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Estoque/Consulta
        public ActionResult Consulta()
        {
            //declarando uma lista da viewmodel
            var model = new List<EstoqueConsultaViewModel>();

            try
            {
                model = Mapper.Map<List<EstoqueConsultaViewModel>>(business.ObterTodos());
            }
            catch(Exception e)
            {
                ViewData["Mensagem"] = e.Message;
            }                

            //enviando a model para a view..
            return View(model);
        }

        [HttpPost] //recebe uma requisição de formulário POST
        public ActionResult CadastrarEstoque(EstoqueCadastroViewModel model)
        {
            //verificar se os campos da classe model
            //passaram nas regras de validação..
            if(ModelState.IsValid)
            {
                try
                {
                    //aplicando o automapper..
                    var estoque = Mapper.Map<Estoque>(model);

                    business.Cadastrar(estoque);

                    //enviando mensagem
                    ViewData["Mensagem"] = "Estoque cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário
                }
                catch(Exception e)
                {
                    ViewData["Mensagem"] = "Erro: " + e.Message;
                }                
            }

            //nome da página..
            return View("Cadastro");
        }

        //GET: Estoque/Edicao/{id}
        public ActionResult Edicao(int id)
        {
            var model = new EstoqueEdicaoViewModel();

            try
            {
                var estoque = business.ObterPorId(id);
                model = Mapper.Map<EstoqueEdicaoViewModel>(estoque);
            }
            catch(Exception e)
            {
                ViewData["Mensagem"] = e.Message;
            }

            //enviando a model para a página
            return View(model);
        }

        [HttpPost]
        public ActionResult AtualizarEstoque(EstoqueEdicaoViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var estoque = Mapper.Map<Estoque>(model);
                    business.Atualizar(estoque);

                    TempData["Mensagem"] = "Estoque atualizado com sucesso.";
                    return RedirectToAction("Consulta");
                }
                catch(Exception e)
                {
                    ViewData["Mensagem"] = e.Message;
                }
            }

            return View("Edicao");
        }

        //GET: Estoque/Exclusao/{id}
        public ActionResult Exclusao(int id)
        {
            try
            {
                business.Excluir(id);

                TempData["Mensagem"] = "Estoque excluído com sucesso.";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            //redirecionar para outro método ActionResult
            return RedirectToAction("Consulta");
        }

    }
}