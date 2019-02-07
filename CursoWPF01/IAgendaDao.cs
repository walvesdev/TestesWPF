using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWPF01
{
    interface IAgendaDao<T> : IDisposable
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
        IList<T> ListarTodos();
        T PesquisarPorId(int id);

    }
}
