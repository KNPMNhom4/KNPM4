using Moq;
using SalesManagementApp.data.repositories;
using SalesManagementApp.Data.Repositories;
using SalesManagementApp.domain.models;
using System.Collections.Generic;
using System.Threading.Tasks;
 

namespace SalesManagementTests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetMock()
        {
            var mockRepo = new Mock<IUserRepository>();

            // Mock phương thức GetUsersAsync()
            mockRepo.Setup(repo => repo.GetUsersAsync())
                .ReturnsAsync(new List<User>
                {
                    new User { Id = 1, Name = "Nguyễn Văn A", Email = "a@gmail.com", Role = "Admin" },
                    new User { Id = 2, Name = "Trần Thị B", Email = "b@gmail.com", Role = "User" }
                });

            return mockRepo;
        }
    }
}
