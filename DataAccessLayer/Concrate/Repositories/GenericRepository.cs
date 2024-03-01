using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		Context context = new Context();
		DbSet<T> _object;

        public GenericRepository()
        {
			_object = context.Set<T>();
        }


        public void Delete(T p)
		{
			var DeletedEntity = context.Entry(p);
			DeletedEntity.State = EntityState.Deleted;
			context.SaveChanges();
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			return _object.SingleOrDefault(filter);
		}

		public void Insert(T p)
		{
			var addedEntity = context.Entry(p);
			addedEntity.State = EntityState.Added;
			context.SaveChanges();
		}

		public List<T> List()
		{
			return _object.ToList();
		}

		public List<T> List(Expression<Func<T, bool>> Filter)
		{
			return _object.Where(Filter).ToList();
		}

		public void Update(T p)
		{
			var UpdateEntity = context.Entry(p);
			UpdateEntity.State = EntityState.Modified;
			context.SaveChanges();
		}
	}
}
