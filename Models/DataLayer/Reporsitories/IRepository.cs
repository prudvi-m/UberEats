namespace UberEats.Models.DataLayer.Reporsitories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> options);
        int Count { get; } 

        T? Get(string id);

        T? Get(QueryOptions<T> options);

        T? Get(int id);

        void Update(T entity);

        void Insert(T entity);

        void Save();

        void Delete(T entity);
    }
}
