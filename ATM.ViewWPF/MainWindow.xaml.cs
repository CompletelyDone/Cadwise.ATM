using ATM.ViewModel;
using ATM.ViewWPF.Services;
using System.Windows;

namespace ATM.ViewWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DialogService dialogService = new DialogService();

            this.DataContext = new MainWindowVM(dialogService);
            
        }
    }
}