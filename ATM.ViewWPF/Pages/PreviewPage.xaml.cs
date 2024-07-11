using System.Windows.Controls;

namespace ATM.ViewWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PreviewPage.xaml
    /// </summary>
    public partial class PreviewPage : Page
    {
        private readonly object parentDataContext;
        public PreviewPage(object parentDataContext)
        {
            InitializeComponent();
            this.parentDataContext = parentDataContext;
        }

        private void NavigateToDispensePage(object sender, System.Windows.RoutedEventArgs e)
        {
            var dispensePage = new DispensePage(parentDataContext);
            this.NavigationService.Navigate(dispensePage);
        }

        private void NavigateToDepositPage(object sender, System.Windows.RoutedEventArgs e)
        {
            var depositCashPage = new DepositCashPage(parentDataContext);
            this.NavigationService.Navigate(depositCashPage);
        }
    }
}
