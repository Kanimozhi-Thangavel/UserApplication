using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Repositary.IRepository;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Repositary
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task Create(User user)
        {

            await _context.Users.AddAsync(user);
            await Save();
        }

        public async Task Delete(User user)
        {

            _context.Users.Remove(user);
            await Save();


        }

        public async Task<List<User>> GetAll()
        {

            List<User> user = await _context.Users.ToListAsync();
            return user;
        }

        public async Task<User> GetById(int id)
        {

            User user = await _context.Users.FindAsync(id);
            return user;

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await Save();

        }
    }
    
}
