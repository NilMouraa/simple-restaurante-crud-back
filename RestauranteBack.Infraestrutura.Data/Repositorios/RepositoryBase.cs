using Microsoft.EntityFrameworkCore;
using RestauranteBack.Infraestrutura.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBack.Infraestrutura.Data.Repositorios
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly RestauranteBackContext Db = new RestauranteBackContext();

        public int TotalRegistros(TEntity entidadeEntity)
        {
            return Db.Set<TEntity>().Count();
        }

        public IList<TEntity> ObterTodos(string includes)
        {
            if (string.IsNullOrEmpty(includes))
            {
                return Db.Set<TEntity>().ToList();
            }
            else { 
                return Db.Set<TEntity>().Include(includes).ToList();
            }
        }

        public IList<TEntity> ObterTodosOrdenacaoAscendente(string campo)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> ObterTodosOrdenacaoDescendente(string campo)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        
        public virtual TEntity ObterPorId(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void ExcluirPorId(int id)
        {
            var entidade = Db.Set<TEntity>().Find(id);
            Db.Set<TEntity>().Remove(entidade);
            Db.SaveChanges();
        }

        public virtual void Excluir(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Remove(entidadeEntity);
            Db.SaveChanges();
        }

        public virtual void Salvar(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Add(entidadeEntity);
            Db.SaveChanges();
        }

        public void SalvarLista(IList<TEntity> entidadeEntity)
        {
            foreach (var Entity in entidadeEntity)
            {
                Db.Set<TEntity>().Add(Entity);
            }
            Db.SaveChanges();
        }

        public virtual void Atualiza(TEntity entidadeEntity)
        {
            Db.Entry(entidadeEntity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void AtualizaLista(IList<TEntity> entidadesEntity)
        {
            foreach (var Entity in entidadesEntity)
            {
                Db.Entry(Entity).State = EntityState.Modified;
            }

            Db.SaveChanges();
        }
        public IList<TEntity> PesquisarParametros(Expression<Func<TEntity, bool>> parametros)
        {
            return Db.Set<TEntity>().Where(parametros).ToList();
        }
        public virtual async Task<string> SalvarAsync(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Add(entidadeEntity);
            await Db.SaveChangesAsync();
            return "Entidade adicionada com sucesso";
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
