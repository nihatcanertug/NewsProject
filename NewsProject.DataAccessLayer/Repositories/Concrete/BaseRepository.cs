using NewsProject.DataAccessLayer.Context;
using NewsProject.DataAccessLayer.Repositories.Interface;
using NewsProject.EntityLayer.Entities.Concrete;
using NewsProject.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.DataAccessLayer.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ProjectContext _content;

        public BaseRepository() => _content = new ProjectContext();
               
        public void Add(T item)
        {
            _content.Set<T>().Add(item);
            Save();        
        }

        public bool Any(Expression<Func<T, bool>> exp) => _content.Set<T>().Any(exp);

        public List<T> GetActive() => _content.Set<T>().Where(x => x.Status != Status.Passive).ToList();

        public List<T> GetAll()
        {
            return _content.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _content.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _content.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _content.Set<T>().Where(exp).ToList();
        }

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = Status.Passive;
            item.DeleteDate = DateTime.Now;
            Save();
        }

        public int Save()
        {
            return _content.SaveChanges();
        }

        public void Update(T item)
        {
            T updateItem = GetById(item.Id);

            DbEntityEntry dbEntityEntry = _content.Entry(updateItem);

            dbEntityEntry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
