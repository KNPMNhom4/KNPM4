using SalesManagementApp.presentation.views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagementApp.Presentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button selectedButton = null; // Lưu nút đang chọn
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string pageTag = clickedButton.Tag.ToString();

            // Đổi màu nền của nút được chọn
            if (selectedButton != null)
            {
                selectedButton.Background = Brushes.Transparent; // Reset nút trước đó
            }
            clickedButton.Background = Brushes.LightBlue; // Làm sáng nút mới
            selectedButton = clickedButton;

            switch (pageTag)
            {
                case "UserManagementPage":
                    MainContentFrame.Navigate(new UserManagementPage());
                    break;
                case "ProductManagementPage":
                    MainContentFrame.Navigate(new ProductManagementPage());
                    break;
                case "ImportManagementPage":
                    MainContentFrame.Navigate(new ImportManagementPage());
                    break;
                case "SalesManagementPage":
                    MainContentFrame.Navigate(new SalesManagementPage());
                    break;
                case "WarehouseManagementPage":
                    MainContentFrame.Navigate(new WarehouseManagementPage());
                    break;
                case "FundManagementPage":
                    MainContentFrame.Navigate(new FundManagementPage());
                    break;
                case "DebtManagementPage":
                    MainContentFrame.Navigate(new DebtManagementPage());
                    break;
                case "WarrantyManagementPage":
                    MainContentFrame.Navigate(new WarrantyManagementPage());
                    break;
                case "AssetManagementPage":
                    MainContentFrame.Navigate(new AssetManagementPage());
                    break;
                case "ReportPage":
                    MainContentFrame.Navigate(new ReportPage());
                    break;
                case "OrderManagementPage":
                    MainContentFrame.Navigate(new OrderManagementPage());
                    break;
                case "SettingsPage":
                    MainContentFrame.Navigate(new SettingsPage());
                    break;
            }
        }
    }
}