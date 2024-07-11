using ATM.ViewModel;
using System.Windows.Controls;

namespace ATM.ViewWPF.Pages
{
    public partial class DepositCashPage : Page
    {
        public MainWindowVM? MainWindowVM { get; set; }
        public DepositCashPage(object parentDataContext)
        {
            InitializeComponent();
            MainWindowVM = parentDataContext as MainWindowVM;
        }

        private void CashButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int number;
                var str = button?.Content?.ToString()?.Split(" ");
                if (str == null && str[1] == null) return;
                if (int.TryParse(str[1], out number))
                {
                    MainWindowVM?.AddBanknote(number);
                }
            }
        }
    }
}
