using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.domain.models
{
    public class User
    {
        public User(int id, string name, string gioitinh, string email, string mota, bool isSelected)
        {
            Id = id;
            Name = name;
            Email = email;
            Gioitinh = gioitinh;
            Mota = mota;
            IsSelected = isSelected;
        }

        public User() {
            IsSelected = false; // Giá trị mặc định
                                }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gioitinh { get; set; }
        public string Email { get; set; }
        public string Mota { get; set; }
        public bool IsSelected { get; set; } // Dùng để chọn nhiều dòng
    }
}
