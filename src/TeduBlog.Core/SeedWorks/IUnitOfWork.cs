namespace TeduBlog.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();// Commit changes to the database asynchronously
    }
}
