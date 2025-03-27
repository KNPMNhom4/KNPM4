namespace SalesManagementApp.domain.models
{
    public class User
    {
        public User(int id, string hoten, string gioitinh, string soDienThoai, string email, string mota, bool isSelected)
            : this()
        {
            Id = id;
            Hoten = hoten;
            Gioitinh = gioitinh;
            SoDienThoai = soDienThoai; // Đúng tên biến đang dùng
            Email = email;
            Mota = mota;
            IsSelected = isSelected;
        }

        public User()
        {
            IsSelected = false; // Giá trị mặc định
        }

        public int Id { get; set; }
        public string Hoten { get; set; }
        public string Gioitinh { get; set; }
        public string SoDienThoai { get; set; } // Đảm bảo có thuộc tính này
        public string Email { get; set; }
        public string Mota { get; set; }
        public bool IsSelected { get; set; }
    }
}
