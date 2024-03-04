namespace Dapper_CRUD_ASP.Net_core_SQL_Server.Infrastructure.IGeneric
{
    public interface ISuperHero<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        //Task<TEntity> GetByIdAsync(int id);
        Task<int> CreateAsync(TEntity entity);
        Task<string> UpdateAsync(TEntity entity,int id);
        Task<string> DeleteAsync(int id);

    }
}
