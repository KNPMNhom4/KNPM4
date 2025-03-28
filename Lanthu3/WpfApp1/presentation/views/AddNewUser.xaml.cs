using SalesManagementApp.domain.models;
using SalesManagementApp.presentation.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagementApp.presentation.views
{

    public partial class AddNewUser : Page
    {
        private UserViewModel _viewModel;

        public AddNewUser(UserViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel; // Lưu ViewModel để cập nhật danh sách
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            string hoten = txtHoTen.Text;
            string gioiTinh = cmbGioiTinh.Text;
            string soDienThoai = txtSoDT.Text;
            string email = txtEmail.Text;
            string moTa = txtMoTa.Text;

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(soDienThoai) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Số điện thoại và Email không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tạo người dùng mới
            User newUser = new User
            {
                Id = new Random().Next(1000, 9999), // ID giả lập
                Hoten = hoten,
                Gioitinh  = gioiTinh,
                SoDienThoai  = soDienThoai,
                Email = email,
                Mota  = moTa
            };

            // Thêm vào danh sách trong ViewModel
            _viewModel.Users.Add(newUser);

            MessageBox.Show("Người dùng đã được lưu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Quay lại trang danh sách người dùng
            this.NavigationService?.GoBack();
        }
    }
}
