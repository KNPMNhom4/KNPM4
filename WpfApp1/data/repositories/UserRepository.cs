using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SalesManagementApp.data.repositories;
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
 
namespace SalesManagementApp.Data.Repositories
{

    
    public class UserRepository: IUserRepository
    {
        private readonly HttpClient _httpClient;
        private List <User> _users;
        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _users = new List<User>
            {  new User { Id = 1, Name = "Nguyễn Văn A",Gioitinh = "nam", Email = "a@gmail.com", Mota = "Admin" },
                new User { Id = 2, Name = "Trần Thị B",Gioitinh = "nu", Email = "b@gmail.com", Mota = "User" },
                new User { Id = 3, Name = "Lê Văn C",Gioitinh = "nam", Email = "c@gmail.com", Mota = "Manager" }
            };
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await GetUsersAsync_m();
            //var response = await _httpClient.GetStringAsync("https://api.example.com/users");
            //return JsonSerializer.Deserialize<List<User>>(response);
        }
        public async Task<List<User>> GetUsersAsync_m()
        {
            await Task.Delay(1000); // Giả lập thời gian tải dữ liệu

            return _users;
        }
        public async Task AddUserAsync(User user)
        {
            await Task.Delay(1000);
            _users.Add(user);
            //var json = JsonSerializer.Serialize(user);
            //var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //await _httpClient.PostAsync("https://api.example.com/users", content);
        }

        public async Task UpdateUserAsync(User user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"https://api.example.com/users/{user.Id}", content);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://api.example.com/users/{id}");
        }
    }
    
}
