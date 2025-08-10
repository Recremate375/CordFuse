using IdentityService.Domain.Models;
using IdentityService.Infrastructure.Context;
using IdentityService.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MsSQLDbContext _context;

        public UserRepository(MsSQLDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);

            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id.ToString()); //change types (Id - string????)
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                var existingUser = await _context.Users.AsTracking().FirstOrDefaultAsync(u => u.Id == user.Id);

                if (existingUser == null)
                {
                    throw new KeyNotFoundException($"User with Id: {user.Id} not found");
                }

                _context.Entry(existingUser).CurrentValues.SetValues(new
                {
                    user.UserName,
                    user.DisplayName,
                    user.AvatarUrl,
                    user.PhoneNumber,
                    user.Email,
                    user.EmailConfirmed,
                    user.PhoneNumberConfirmed,
                    user.LockoutEndDateUtc,
                    user.LockoutEnabled,
                    user.AccessFailedCount,
                    user.TwoFactorEnabled
                });

                await SaveAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
