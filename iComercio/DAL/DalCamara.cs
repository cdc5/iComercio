using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace iComercio.DAL
{
    public class DalCamara :IDisposable
    {
        public CamaraContext context = new CamaraContext();

        /*Operaciones Genericas */
        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null,
                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                          string includeProperties = "") where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

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

        public TEntity GetByID<TEntity>(object id) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            return context.Set<TEntity>().Find(id);
        }

        public void Agregar<TEntity>(TEntity entity) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Borrar<TEntity>(object id) where TEntity : class
        {
            TEntity entityToDelete = context.Set<TEntity>().Find(id);
            Borrar<TEntity>(entityToDelete);
        }

        public void Borrar<TEntity>(TEntity entityToDelete) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }

        public void Actualizar<TEntity>(TEntity entityToUpdate) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }

        public BindingList<TEntity> ToBindingList<TEntity>() where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Load();
            return dbSet.Local.ToBindingList();
        }

        public void AgregarBulk<TEntity>(List<TEntity> lista) where TEntity : class
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            foreach (TEntity cli in lista)
            {
                Agregar<TEntity>(cli);
            }
            context.Configuration.AutoDetectChangesEnabled = true;
        }

        public void AgregarRange<TEntity>(List<TEntity> lista) where TEntity : class
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            //Este es el metodo mas rapido de los comparando con los tres anteriores
            //tendria que probar deshabilitaando tambien el autoDetectChangesEnabled
            context.Set<TEntity>().AddRange(lista);
            Save();
            context.Configuration.AutoDetectChangesEnabled = true;
        }
        /****************************************/

        public List<MorosoEnCamara> ObtenerMorosoEnCamara(double dni,string nombre)
        {
            return context.sp_ObtenerMorosoEnCamara(dni, nombre).ToList();
        }

        public List<Entidad> ObtenerEntidades(string codent, string noment)
        {
            return context.sp_Entidad_sel(codent,noment).ToList();
        }

        public List<Morcam> ObtenerMorcam(double dni,string nombre,string emprca)
        {
            return context.sp_Morcam_sel(dni,nombre,emprca).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
