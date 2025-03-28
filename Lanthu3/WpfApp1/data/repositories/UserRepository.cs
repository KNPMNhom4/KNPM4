using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using SalesManagementApp.data.repositories;
using SalesManagementApp.domain.models;

namespace SalesManagementApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.json");
        private List<User> _users;

        public UserRepository()
        {
            LoadUsersFromFile();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Task.Delay(500); // Giả lập độ trễ
            return _users;
        }

            private void LoadUsersFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                }
                else
                {
                    _users = new List<User>();
                    SaveUsersToFile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
                _users = new List<User>();
            }
        }

        private void SaveUsersToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu file: {ex.Message}");
            }
        }

        public async Task AddUserAsync(User user)
        {
            await Task.Delay(500);
            int maxId = _users.Any() ? _users.Max(u => u.Id) : 0;
            user.Id = maxId + 1;
            SaveUsersToFile();
        }

        public async Task DeleteUserAsync(int id)
        {
            await Task.Delay(500);
            _users.RemoveAll(u => u.Id == id);
            SaveUsersToFile(); // Lưu lại danh sách sau khi xóa
        }
    }
}
