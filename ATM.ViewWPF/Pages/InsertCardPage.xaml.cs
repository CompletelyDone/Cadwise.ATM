using System.Windows.Controls;

namespace ATM.ViewWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для InsertCardPage.xaml
    /// </summary>
    public partial class InsertCardPage : Page
    {
        private readonly object parentDataContext;
        public InsertCardPage(object parentDataContext)
        {
            InitializeComponent();
            this.parentDataContext = parentDataContext;
        }

        private void NavigateToPreviewPage(object sender, System.Windows.RoutedEventArgs e)
        {
            var previewPage = new PreviewPage(parentDataContext);
            this.NavigationService.Navigate(previewPage);
        }
    }
}
