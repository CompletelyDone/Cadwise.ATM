using ATM.ViewModel.Base;
using ATM.ViewModel.Interfaces;

namespace ATM.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly ATM.Model.ATM atm;
        private readonly IDialogService dialogService;
        public IDispenser? ATMService { get; set; }
        public MainWindowVM(IDialogService dialogService)
        {
            CommandButtons = new CommandButtons();
            atm = new ATM.Model.ATM(Guid.NewGuid(), 2500);
            this.dialogService = dialogService;
        }
        public CommandButtons CommandButtons { get; set; }
    }
}
