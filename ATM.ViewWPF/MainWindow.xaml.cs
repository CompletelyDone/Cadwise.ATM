using ATM.ViewModel;
using ATM.ViewWPF.Pages;
using ATM.ViewWPF.Services;
using System.Windows;
using System.Windows.Navigation;

namespace ATM.ViewWPF
{
    public partial class MainWindow : Window
    {
        private NavigationService navigationService;
        public MainWindow()
        {
            InitializeComponent();
            navigationService = CenterFrame.NavigationService;
            
            DialogService dialogService = new DialogService();
            this.DataContext = new MainWindowVM(dialogService);

            var insertCardPage = new InsertCardPage(this.DataContext);
            var previewPage = new PreviewPage(this.DataContext);
            navigationService.Navigate(insertCardPage);
        }

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            if (this.navigationService.CanGoBack)
            {
                this.navigationService.GoBack();
            }
        }
    }
}