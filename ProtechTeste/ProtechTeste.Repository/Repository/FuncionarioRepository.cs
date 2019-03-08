using ProtechTeste.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtechTeste.Domain.Objects;
using ProtechTeste.Repository.Memory;
using ProtechTeste.Repository.Context;

namespace ProtechTeste.Repository.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        ProtechContext _context = new ProtechContext();

        public FuncionarioRepository()
        {
            _context.LoadJson();
        }

        public Funcionario Buscar(int id)
        {
           return _context.Funcionarios.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Adicionar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            var listFunc = _context.Funcionarios;

            if (listFunc != null)
            {
                listFunc.Add(funcionario);
                MemoryCacher.Add("ProtechContext", listFunc);
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            var func = _context.Funcionarios.Where(p => p.Nome.Equals(funcionario.Nome));
            _context.Funcionarios.Add(funcionario);
        }

        public void AdicionarExperiencia(int id, Experiencia experiencia)
        {            
            var func = _context.Funcionarios.Where(p => p.Id == id).FirstOrDefault();                        
            func.Experiencia.Add(experiencia);            
        }

        public void Excluir(Funcionario funcionario)
        {
            var listFunc = _context.Funcionarios;
            listFunc.Remove(funcionario);
            MemoryCacher.Add("ProtechContext", listFunc);            
        }

        public void AdicionarFormacao(int id, Formacao formacao)
        {
            var listFunc = _context.Funcionarios;

            var func = listFunc.Where(p => p.Id == id).FirstOrDefault();
            listFunc.Remove(func);

            func.Formacao.Add(formacao);
            Adicionar(func);
        }

        public IEnumerable<Funcionario> ListarTodos()
        {
            return _context.Funcionarios;
        }

        public Funcionario ObterPorId(int Id)
        {
            return _context.Funcionarios.Where(p=> p.Id == Id).FirstOrDefault();
        }
    }
}
