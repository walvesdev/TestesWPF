using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWPF01
{
    public class ContatoDao : IAgendaDao<Contato>
    {
        AgendaContext banco;
        public ContatoDao()
        {
            this.banco = new AgendaContext();
        }
        
        public Task<List<Contato>> ListarTodos()
        {
            return Task.Run(() =>
            {
                return banco.Contatos.ToList();
            });
        }
       

        public void Inserir(Contato obj)
        {
            banco.Contatos.Add(obj);
            banco.SaveChanges();
        }

        public void Alterar(Contato obj)
        {
            banco.Contatos.Update(obj);
            banco.SaveChanges();
        }

        public void Excluir(Contato obj)
        {
            banco.Contatos.Remove(obj);
            banco.SaveChanges();
        }

        public Contato PesquisarPorId(int id)
        {
            return banco.Contatos.Find(id);
        }
        public void Dispose()
        {
            banco.Dispose();
        }
        public Task<List<Contato>> PesquisaPorNome(string nome)
        {
            return Task.Run(() => {
                return banco.Contatos.Where(c => c.Nome.Contains(nome.Trim())).AsParallel().ToList();
            });
        }
        public int ContarContatos()
        {
            return banco.Contatos.Count();
        }
    }
}
