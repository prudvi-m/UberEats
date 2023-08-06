using Microsoft.EntityFrameworkCore;

namespace UberEats.Models.DataLayer.Reporsitories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected UberContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(UberContext ctx)
        {
            context = ctx;dbset = context.Set<T>();
        }

        public int Count => 
            dbset.Count();

        public virtual IEnumerable<T> List(QueryOptions<T> options) =>
            BuildQuery(options).ToList();

        public virtual T? Get(string id) => dbset.Find(id);
        public virtual T? Get(int id) => dbset.Find(id);
        public virtual T? Get(QueryOptions<T> options) =>
            BuildQuery(options).FirstOrDefault();

        public virtual void Update(T entity) => dbset.Update(entity);
        public virtual void Delete(T entity) => dbset.Remove(entity);
        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Save() => context.SaveChanges();

        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = dbset;
            foreach (string include in options.GetIncludes())
            {
                query = query
                    .Include(include);
            }
            if (options.HasWhere)
            {
                query = query
                    .Where(options.Where);
            }
            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")query = query
                        .OrderBy(options.OrderBy);
                else query = query
                        .OrderByDescending(options.OrderBy);
            }
            if (options.HasPaging)
            {
                query = query
                    .PageBy(options.PageNumber, options.PageSize);
            }return query;
        }
    }

}
