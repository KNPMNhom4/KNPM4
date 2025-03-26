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
    /// <summary>
    /// Interaction logic for AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Page
    {
        public AddNewUser()
        {
            InitializeComponent();
            DataContext = new AddUserViewModel();
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            string hoten = txtHoTen.Text;
            string gioiTinh = cmbGioiTinh.Text;
            string soDienThoai = txtSoDT.Text;
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string moTa = txtMoTa.Text;

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(soDienThoai) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Số điện thoại và Email không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Hiển thị thông báo lưu thành công (giả lập)
            MessageBox.Show("Người dùng đã được lưu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
