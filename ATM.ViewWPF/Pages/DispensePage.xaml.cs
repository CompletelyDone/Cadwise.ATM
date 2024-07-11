using ATM.ViewModel;
using ATM.ViewWPF.Services;
using System.Windows.Controls;

namespace ATM.ViewWPF.Pages
{
    public partial class DispensePage : Page
    {
        private TextBlock InputTextBlock;
        private MainWindowVM? MainWindowVM;
        public DispensePage(object parentDataContext)
        {
            InitializeComponent();
            InputTextBlock = this.DispenseInputTextBlock;
            MainWindowVM = parentDataContext as MainWindowVM;
            if (MainWindowVM != null)
            {
                MainWindowVM.ATMService = new Dispenser(InputTextBlock);
            }
        }

        private void NumButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int number;
                if (int.TryParse(button.Content.ToString(), out number))
                {
                    UpdateInputTextBlock(number);
                }
                else if (button.Content.ToString() == "⌫")
                {
                    DeleteLastCharacter();
                }
            }
        }
        private void DispenseButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MainWindowVM == null) return;
            if (InputTextBlock.Text.ToString().Length < 2) return;
            MainWindowVM.Dispense(Int32.Parse(InputTextBlock.Text.ToString()));
            InputTextBlock.Text = "0";
        }

        private void DeleteLastCharacter()
        {
            if (InputTextBlock.Text.Length > 1)
            {
                InputTextBlock.Text = InputTextBlock.Text.Substring(0, InputTextBlock.Text.Length - 1);
            }
            else
            {
                InputTextBlock.Text = "0";
            }
        }

        private void UpdateInputTextBlock(int number)
        {
            if (InputTextBlock.Text == "0")
            {
                InputTextBlock.Text = number.ToString();
            }
            else
            {
                InputTextBlock.Text += number.ToString();
            }
        }
    }
}
