 
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SalesManagementApp.presentation.viewmodels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        private ObservableCollection<User> users = new();

        public UserViewModel(IUserService userService)
        {
            _userService = userService;
            LoadUsersCommand = new AsyncRelayCommand(LoadUsers);
            AddUserCommand = new AsyncRelayCommand<User>(AddUser);
            DeleteUserCommand = new AsyncRelayCommand<int>(DeleteUser);
        }

        public IAsyncRelayCommand LoadUsersCommand { get; }
        public IAsyncRelayCommand<User> AddUserCommand { get; }
        public IAsyncRelayCommand<int> DeleteUserCommand { get; }
        private async Task LoadUsers()
        {
            var userList = await _userService.GetUsersAsync();
            Users.Clear();
            foreach (var user in userList)
            {
                Users.Add(user);
            }
        }
        private async Task AddUser(User user)
        {
            await _userService.AddUserAsync(user);
            await LoadUsers();
        }
        private async Task DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            await LoadUsers();
        }
    }
}
