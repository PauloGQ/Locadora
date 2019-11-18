using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Instancia a controller de RN (SERVICE)
            ClienteController controller = new ClienteController();

            List<Cliente> lst = controller.Listar();

            return View(lst);
        }
        public ActionResult ListaFilme()
        {
            //Instancia a controller de RN (SERVICE)
            FilmeController controller = new FilmeController();

            List<Filme> lst = controller.Listar();

            return View(lst);
        }

        public ActionResult ListaFuncionario()
        {
            //Instancia a controller de RN (SERVICE)
            FuncionarioController controller = new FuncionarioController();

            List<Funcionario> lst = controller.Listar();

            return View(lst);
        }
        public ActionResult ListaLocacao()
        {
            //Instancia a controller de RN (SERVICE)
            LocacaoController controller = new LocacaoController();

            List<Locacao> lst = controller.Listar();

            return View(lst);
        }
        public ActionResult Visualizar(int id)
        {
            ClienteController controller = new ClienteController();
            var registro = controller.Buscar(id);

            return View(registro);
        }

        public ActionResult VisualizarFilme(int id)
        {
            FilmeController controller = new FilmeController();
            var registro = controller.Buscar(id);

            return View(registro);
        }

        public ActionResult VisualizarFuncionario(int id)
        {
            FuncionarioController controller = new FuncionarioController();
            var registro = controller.Buscar(id);

            return View(registro);
        }
        public ActionResult VisualizarLocacao(int id)
        {
            LocacaoController controller = new LocacaoController();
            var registro = controller.Buscar(id);

            return View(registro);
        }

        public ActionResult Inserir()
        {
            return View();
        }
        public ActionResult InserirFilme()
        {
            return View();
        }
        public ActionResult InserirFuncionario()
        {
            return View();
        }
        public ActionResult InserirLocacao()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inserir(Cliente registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            ClienteController controller = new ClienteController();
            controller.Inserir(registro);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult InserirFilme(Filme registro)
        {
            
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            FilmeController controller = new FilmeController();
           
            controller.Inserir(registro);

            return RedirectToAction("ListaFilme");
        }
        [HttpPost]
        public ActionResult InserirFuncionario(Funcionario registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            FuncionarioController controller = new FuncionarioController();
            controller.InserirFuncionario(registro);

            return RedirectToAction("ListaFuncionario");
        }
        [HttpPost]
        public ActionResult InserirLocacao(Locacao registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            LocacaoController controller = new LocacaoController();
            controller.Inserir(registro);

            return RedirectToAction("ListaLocacao");
        }
        public ActionResult Editar(int id)
        {
            ClienteController controller = new ClienteController();
            var registro = controller.Buscar(id);

            return View(registro);
        }
        public ActionResult EditarFuncionario(int id)
        {
            FuncionarioController controller = new FuncionarioController();
            var registro = controller.Buscar(id);

            return View(registro);
        }
        public ActionResult EditarLocacao(int id)
        {
           LocacaoController controller = new LocacaoController();
            var registro = controller.Buscar(id);

            return View(registro);
        }
        [HttpPost]
        public ActionResult Editar(Cliente registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            ClienteController controller = new ClienteController();
            controller.Atualizar(registro);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditarFuncionario(Funcionario registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            FuncionarioController controller = new FuncionarioController();
            controller.Atualizar(registro);

            return RedirectToAction("ListaFuncionario");
        }
        [HttpPost]
        public ActionResult EditarLocacao(Locacao registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            LocacaoController controller = new LocacaoController();
            controller.Atualizar(registro);

            return RedirectToAction("ListaLocacao");
        }

        public ActionResult Excluir(int id)
        {
            ClienteController controller = new ClienteController();
            var registro = controller.Buscar(id);

            return View(registro);
        }
        public ActionResult ExcluirFuncionario(int id)
        {
            FuncionarioController controller = new FuncionarioController();
            var registro = controller.Buscar(id);

            return View(registro);
        }
        public ActionResult ExcluirLocacao(int id)
        {
            LocacaoController controller = new LocacaoController();
            var registro = controller.Buscar(id);

            return View(registro);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmar(int id)
        {
            ClienteController controller = new ClienteController();
            controller.Excluir(id);

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("ExcluirFuncionario")]
        public ActionResult ExcluirFuncionarioConfirmar(int id)
        {
            FuncionarioController controller = new FuncionarioController();
            controller.Excluir(id);

            return RedirectToAction("ListaFuncionario");
        }
        [HttpPost, ActionName("ExcluirLocacao")]
        public ActionResult ExcluirLocacaoConfirmar(int id)
        {
            LocacaoController controller = new LocacaoController();
            controller.Excluir(id);

            return RedirectToAction("ListaLocacao");
        }
    }
}