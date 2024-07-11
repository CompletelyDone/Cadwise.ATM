using ATM.ViewModel.Interfaces;
using System.Windows;

namespace ATM.ViewWPF.Services
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);            
        }
    }
}
