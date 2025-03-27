using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SalesManagementApp.domain.usecases;
using System.Windows;
using SalesManagementApp.domain.models;

namespace SalesManagementApp.presentation.viewmodels
{
    public partial class AddUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        private string hoten;

        [ObservableProperty]
        private string gioiTinh;

        [ObservableProperty]
        private string soDienThoai;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string moTa;

        public AddUserViewModel(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [RelayCommand]
        private async Task SaveUserAsync()
        {
            if (string.IsNullOrWhiteSpace(Hoten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newUser = new User(0, Hoten, GioiTinh, SoDienThoai, Email, MoTa, false);
            await _userService.AddUserAsync(newUser);

            MessageBox.Show($"Họ và Tên: {Hoten}\nGiới Tính: {GioiTinh}\nSố ĐT: {SoDienThoai} \nEmail: {Email}\nMô Tả: {MoTa}",
                            "Thông Tin Người Dùng", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
