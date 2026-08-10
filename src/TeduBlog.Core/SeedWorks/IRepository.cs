using System.Linq.Expressions;

namespace TeduBlog.Core.SeedWorks
{
    public interface IRepository<T, Key> where T : class
    {
        Task<T> GetByIdAsync(Key id);// lấy 1 dữ liệu của bảng dựa vào id của dữ liệu đó trong bảng.
        Task<IEnumerable<T>> GetAllAsync();// lấy tất cả dữ liệu của bảng.
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
