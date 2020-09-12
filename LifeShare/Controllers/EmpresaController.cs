using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeShare.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeShare.Controllers
{
    public class EmpresaController : Controller
    {
        //simulando bd com lista 
        private static List<Empresa> _banco = new List<Empresa>();
        //listagem de empresas 
        public IActionResult Index()
        {
            //retorno da lista empresas
            return View(_banco);
        }

        [HttpPost]
        public IActionResult Cadastrar(Empresa empresa)
        {
            empresa.Codigo = _banco.Count + 1; //Count == size() --> gerando codigos automaticos  
            _banco.Add(empresa);
            TempData["msg"] = "Empresa cadastrada!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Editar(Empresa empresa)
        {
            //Atualizar o objeto na lista (procurar a posição do usuário na lista e substitui-lo)
            _banco[ _banco.FindIndex(u => u.Codigo == empresa.Codigo ) ] = empresa;
            //Mensagem de sucesso
            TempData["msg"] = "Empresa atualizada!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var empresa = _banco.Find(empresa => empresa.Codigo == id);
            //Enviar o usuário para a view
            return View(empresa);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            //Remover empresa do bd
            _banco.RemoveAt(_banco.FindIndex(u => u.Codigo == id));
            //Mensagem de sucesso
            TempData["msg"] = "Empresa removida com sucesso!";
            //Redirect para a index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Pesquisar(int Codigo)
        {

            var empresa = _banco.Find(e => e.Codigo == Codigo);

            return View(empresa);
        }

        [HttpGet]
        public IActionResult Pesquisar()
        {

            return View();
        }




    }
}
