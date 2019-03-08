using ProtechTeste.Repository.Context;
using ProtechTeste.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProtechTeste.Repository.Interfaces;
using ProtechTeste.Repository.Repository;
using ProtechTeste.Domain.Objects;

namespace ProtechTeste.Web.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioRepository _funcionarioRepository = new FuncionarioRepository();

        // GET: Funcionarios
        public ActionResult Index()
        {
            try
            {
                var funcs = _funcionarioRepository.ListarTodos();
                return View(funcs);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Excluir(int Id)
        {
            try
            {
                var func = _funcionarioRepository.ObterPorId(Id);
                _funcionarioRepository.Excluir(func);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        
        #region Formação
        public ActionResult NovaFormacao(int Id)
        {
            try
            {
                var func = _funcionarioRepository.ObterPorId(Id);
                ViewBag.Funcionario = func.Nome;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult SalvarNovaFormacao(int Id, Formacao formacao)
        {
            try
            {
                _funcionarioRepository.AdicionarFormacao(Id, formacao);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion 

        #region Experiência
        public ActionResult Experiencia(int Id)
        {
            try
            {
                var func = _funcionarioRepository.ObterPorId(Id);
                ViewBag.FuncionarioId = func.Id;
                ViewBag.Funcionario = func.Nome;
                return View(func.Experiencia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult NovaExperiencia(int Id)
        {
            try
            {
                var func = _funcionarioRepository.ObterPorId(Id);
                ViewBag.FuncionarioId = func.Id;
                ViewBag.Funcionario = func.Nome;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult SalvarNovaExperiencia(ExperienciaVM experiencia)
        {
            try
            {
                var exp = new Experiencia
                {
                    DetalheExperiencia = experiencia.DetalheExperiencia,
                    Tecnologia = experiencia.Tecnologia,
                    TempoExperiencia = experiencia.TempoExperiencia

                };                
                _funcionarioRepository.AdicionarExperiencia(experiencia.Id, exp);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }            
        }
        #endregion
    }
}