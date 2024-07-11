using ATM.ViewModel.Interfaces;
using System.Windows.Controls;

namespace ATM.ViewWPF.Services
{
    public class Dispenser : IDispenser
    {
        private readonly TextBlock textBlock;
        public Dispenser(TextBlock textBlock)
        {
            this.textBlock = textBlock;
        }
        public int DispenseBanknotes()
        {
            int returning = 0;
            Int32.TryParse(textBlock.Text, out returning);
            return returning;
        }
    }
}
