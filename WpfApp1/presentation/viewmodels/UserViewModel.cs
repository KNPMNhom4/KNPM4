﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using SalesManagementApp.domain.models;
using SalesManagementApp.data.repositories;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class UserViewModel : BaseViewModel
{
    private readonly IUserRepository _userRepository;
    public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

    public ICommand LoadUsersCommand { get; }
    public ICommand AddUserCommand { get; }
    public ICommand DeleteUserCommand { get; } // ✅ Thêm command xóa

    public UserViewModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        LoadUsersCommand = new RelayCommand(async () => await LoadUsers());
        AddUserCommand = new RelayCommand<User>(async (user) => await AddUser(user));
        DeleteUserCommand = new RelayCommand<User>(async (user) => await DeleteUser(user)); // ✅ Khởi tạo command xóa
    }

    private async Task LoadUsers()
    {
        Users.Clear(); // Xóa dữ liệu cũ trước khi load
        var users = await _userRepository.GetUsersAsync();
        foreach (var user in users)
        {
            Users.Add(user);
        }
    }

    private async Task AddUser(User user)
    {
        await _userRepository.AddUserAsync(user);
        await LoadUsers(); // Tải lại dữ liệu từ file JSON và cập nhật giao diện
    }

    public async Task AddUserToRepository(User user)
    {
        await _userRepository.AddUserAsync(user);
        await LoadUsers(); // Cập nhật lại danh sách sau khi thêm
    }

    // ✅ Hàm xử lý xóa người dùng
    public async Task DeleteUser(User user)
    {
        if (user == null) return;

        await _userRepository.DeleteUserAsync(user.Id);
        await LoadUsers(); // Tải lại danh sách sau khi xóa
    }
}
