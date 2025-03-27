using Moq;
using SalesManagementApp.data.repositories;
using SalesManagementApp.data.services;
using SalesManagementApp.Data.Repositories;
using SalesManagementApp.domain.models;
using SalesManagementTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SalesManagementApp.Services
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _mockRepo;

        public UserServiceTests()
        {
            _mockRepo = MockUserRepository.GetMock(); // ✅ Lấy mock object từ phương thức static
            _userService = new UserService(_mockRepo.Object); // ✅ Truyền object vào UserService

        }

        [Fact] // Kiểm thử GetUsersAsync()
        public async Task GetUsers_ShouldReturnUsers()
        {
            // Act
            var users = await _userService.GetUsersAsync();

            // Assert
            Assert.Equal(2, users.Count);
            Assert.Equal("Nguyễn Văn A", users[0].Name);
        }

        [Fact] // Kiểm thử lỗi khi thêm User không có tên
        public async Task AddUser_ShouldThrowException_WhenNameIsEmpty()
        {
            var user = new User { Id = 3, Name = "", Email = "c@gmail.com", Role = "User" };

            await Assert.ThrowsAsync<ArgumentException>(() => _userService.AddUserAsync(user));
        }

        [Fact] // Kiểm thử xóa User thành công
        public async Task DeleteUser_ShouldNotThrowException_WhenIdIsValid()
        {
            var exception = await Record.ExceptionAsync(() => _userService.DeleteUserAsync(1));
            Assert.Null(exception);
        }
    }
}
