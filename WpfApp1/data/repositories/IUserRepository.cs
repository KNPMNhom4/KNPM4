using SalesManagementApp.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.data.repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
