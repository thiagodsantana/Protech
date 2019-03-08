using ProtechTeste.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtechTeste.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        Funcionario Buscar(int id);
        void Adicionar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
        void Excluir(Funcionario funcionario);
        IEnumerable<Funcionario> ListarTodos();
        Funcionario ObterPorId(int Id);

        void AdicionarExperiencia(int id, Experiencia experiencia);
        void AdicionarFormacao(int id, Formacao formacao);
    }
}
