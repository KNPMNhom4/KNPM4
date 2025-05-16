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
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "repositories", "user.json");
        private List<User> _users;

        private void EnsureFileExists()
        {
            string directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]"); // Tạo file JSON rỗng nếu chưa có
            }
        }

        public UserRepository()
        {
            EnsureFileExists(); // ✅ Gọi hàm tạo file nếu cần
            LoadUsersFromFile(); // ✅ Sau đó mới load dữ liệu
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

            _users.Add(user); // ✅ BỔ SUNG DÒNG NÀY

            SaveUsersToFile(); // ✅ Ghi file với dữ liệu mới
        }

        public async Task DeleteUserAsync(int id)
        {
            await Task.Delay(500); // giả lập độ trễ
            _users.RemoveAll(u => u.Id == id);
            SaveUsersToFile(); // ✅ lưu lại danh sách sau khi xoá
        }
    }
}
