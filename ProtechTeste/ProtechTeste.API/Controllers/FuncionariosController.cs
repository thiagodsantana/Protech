using ProtechTeste.Domain.Objects;
using ProtechTeste.Repository.Context;
using ProtechTeste.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProtechTeste.API.Controllers
{
    public class FuncionariosController : ApiController
    {
        private FuncionarioRepository _funcionarioRepository;

        // GET: Funcionarios
        [System.Web.Http.HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            _funcionarioRepository = new FuncionarioRepository();
            return _funcionarioRepository.ListarTodos();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CadastrarExperiencia")]
        public bool CadastrarExperiencia([FromBody]ExperienciaVM experiencia)
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}