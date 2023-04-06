using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Diagnostics;
using iComercio.Models;


namespace iComercio.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ComercioContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ComercioContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null,
                                                string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter); 
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                 return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

         public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            //try
            //{
                dbSet.Add(entity);
                context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    Debug.Write(ex.Message);
            //}
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            context.SaveChanges();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
                context.SaveChanges();            
        }

        public virtual BindingList<TEntity> ToBindingList()
        {
            dbSet.Load();
            return dbSet.Local.ToBindingList();
        }

        public virtual void RecargarEntidad(TEntity entity)
        {
            context.Entry(entity).Reload();
        }

        //public static void ReloadNavigationProperty<TEntity, TElement>(this DbContext context, TEntity entity,
        //                                            Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
        //    where TElement : class
        //{
        //    context.Entry(entity).Collection<TElement>(navigationProperty).Query();
        //}

    }
}
