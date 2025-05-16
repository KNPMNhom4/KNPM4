using SalesManagementApp.domain.models;
using SalesManagementApp.presentation.viewmodels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SalesManagementApp.presentation.views
{
    public partial class AddNewUser : Page
    {
        private UserViewModel _viewModel;

        public AddNewUser(UserViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private async void SaveUser_Click(object sender, RoutedEventArgs e) // ✅ THÊM async
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
                Hoten = hoten,
                Gioitinh = gioiTinh,
                SoDienThoai = soDienThoai,
                Email = email,
                Mota = moTa
            };

            // ✅ Gọi đúng hàm xử lý trong ViewModel để lưu xuống file JSON
            await _viewModel.AddUserToRepository(newUser);

            MessageBox.Show("Người dùng đã được lưu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Quay lại trang danh sách người dùng
            this.NavigationService?.GoBack();
        }
    }
}
