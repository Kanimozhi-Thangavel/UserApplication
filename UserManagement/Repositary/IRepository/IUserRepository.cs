using UserManagement.Models;

namespace UserManagement.Repositary.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task Create(User user);

        Task Update(User user);

        Task Delete(User user);

        Task Save();
    }
}
