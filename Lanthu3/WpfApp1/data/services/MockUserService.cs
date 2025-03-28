using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.data.services
{
    public class MockUserService : IUserService
    {
        public Task<List<User>> GetUsersAsync() => Task.FromResult(new List<User>
    {
        new User { Id = 1, Hoten = "Test User", Email = "test@example.com", Mota = "Admin" }
    });

        public Task AddUserAsync(User user) => Task.CompletedTask;
        public Task UpdateUserAsync(User user) => Task.CompletedTask;
        public Task DeleteUserAsync(int id) => Task.CompletedTask;
    }
}
