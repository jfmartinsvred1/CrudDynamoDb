using CrudDynamoDB.Models;

namespace CrudDynamoDB.Repos
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task Update(User user); 
        Task Delete(string site,string email);
        Task<User> FindByEmail(string site ,string email);
        Task<IEnumerable<User>> GetUsers(string site);
    }
}
