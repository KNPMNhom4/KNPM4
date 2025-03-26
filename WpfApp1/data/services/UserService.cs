using SalesManagementApp.data.repositories;
using SalesManagementApp.Data.Repositories;
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.data.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException("Tên người dùng không được để trống");

            await _userRepository.AddUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            users.RemoveAll(u => string.IsNullOrEmpty(u.Email)); // Xử lý logic nghiệp vụ
            return users;
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }

}
