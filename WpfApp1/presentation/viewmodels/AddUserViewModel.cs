using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SalesManagementApp.domain.usecases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using SalesManagementApp.domain.models;

namespace SalesManagementApp.presentation.viewmodels
{
    public partial class AddUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        private string _hoten;

        [ObservableProperty]
        private string _gioiTinh;

        [ObservableProperty]
        private string _soDienThoai;

        [ObservableProperty]
        private string _diaChi;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _moTa;

        public IRelayCommand SaveCommand { get;  }


        public AddUserViewModel()
        {
            SaveCommand = new RelayCommand(SaveUser);

        }

        [RelayCommand]

        private void SaveUser()
        {
            User NewUser = new User(5,_hoten,_gioiTinh,_email, _moTa, false);
            _userService.AddUserAsync(NewUser);
            MessageBox.Show($" Họ và tên: {Hoten} Giới Tính: {GioiTinh}\nSố ĐT: {SoDienThoai}\nĐịa Chỉ: {DiaChi}\nEmail: {Email}\nMô Tả: {MoTa}", 
                            "Thông Tin Người Dùng");
        }


    }
}
