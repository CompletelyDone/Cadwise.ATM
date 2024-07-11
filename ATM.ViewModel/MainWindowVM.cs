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
            atm = new ATM.Model.ATM(Guid.NewGuid(), 2500);
            this.dialogService = dialogService;
            Balance = UpdateBalance();
        }

        private string balance = string.Empty;
        public string Balance 
        { 
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged();
            }
        }
        private string UpdateBalance()
        {
            var str = string.Empty;
            foreach (var item in atm.GetTotalBanknotes())
            {
                str += item.denomination + ":" + item.count + ". ";
            }
            return $"Баланс банкомата: {atm.GetBalance()}. В наличии {str}";
        }

        public void Dispense(int sum)
        {
            if (atm.GetBalance() < sum)
            {
                dialogService.ShowMessage("В банкомате недостаточно средств");
                return;
            }
            var banknotes = atm.DispenseBanknotes(sum);
            if (banknotes.Count == 0)
            {
                dialogService.ShowMessage("В банкомате нет размена");
                return;
            }
            foreach (var banknote in banknotes)
            {
                dialogService.ShowMessage($"Вы получили: {banknote.Denomination}");
            }
            Balance = UpdateBalance();
        }

        public void AddBanknote(int denomination)
        {
            if (denomination % 10 != 0)
            {
                dialogService.ShowMessage("Купюра фальшивая");
                return;
            }
            atm.AddBanknote(denomination, new Model.Banknote(Guid.NewGuid(), denomination));
            Balance = UpdateBalance();
        }
    }
}
