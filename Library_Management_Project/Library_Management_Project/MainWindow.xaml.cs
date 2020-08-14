using Library_Management_Project.Helper;
using System.Windows;
using Telerik.Windows.Controls;

namespace Library_Management_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LocalizationManager.Manager = new CustomLocalizationManager();
            InitializeComponent();
        }
    }
}
