using IdentityService.Domain.Models;

namespace IdentityService.Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsersAsync();

        public Task<User> GetUserByIdAsync(int id);

        public Task<User> CreateUserAsync(User user);

        public Task UpdateUserAsync(User user);

        public Task SaveAsync();
    }
}
