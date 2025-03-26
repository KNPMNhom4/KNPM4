using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for UserManagementPage.xaml
    /// </summary>
    public partial class UserManagementPage : Page
    {
        public UserManagementPage()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetService<UserViewModel>();
        }
        private void UserManagementPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is UserViewModel viewModel)
            {
                if (viewModel.LoadUsersCommand.CanExecute(null))
                {
                    viewModel.LoadUsersCommand.Execute(null);
                }
            }
        }
        private void ShowAddUserDialog(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNewUser());
        }
    }
}
