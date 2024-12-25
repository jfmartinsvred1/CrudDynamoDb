using Amazon.DynamoDBv2.DataModel;
using CrudDynamoDB.Models;

namespace CrudDynamoDB.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IDynamoDBContext _context;

        public UserRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.SaveAsync(user); 
        }

        public async Task Delete(string site,string email)
        {
            await _context.DeleteAsync<User>(site,email);
        }

        public async Task<User> FindByEmail(string site, string email)
        {
            var itens = await _context.QueryAsync<User>(site,Amazon.DynamoDBv2.DocumentModel.QueryOperator.Equal, new object[] {email})
                .GetRemainingAsync();
            return itens.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetUsers(string site)
        {
            return await _context.QueryAsync<User>(site).GetRemainingAsync();
        }

        public async Task Update(User user)
        {
            await _context.SaveAsync(user);
        }
    }
}
