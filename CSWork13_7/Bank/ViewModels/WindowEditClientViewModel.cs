using CSWork12_5.Bank.Interfaces;
using CSWork12_5.Bank.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task.Common;

namespace CSWork12_5.Bank.ViewModels
{
    public class WindowEditClientViewModel : INotifyPropertyChanged
    {
        private ICommand? _clickSavePerson;
        private ICommand? _clickCancel;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Action<IBankClient> OnSaveBankClient;
        public Action OnExit;

        public IBankClient IsEditedBankClient { get; set; }

        public ICommand? ClickSavePerson
        {
            get
            {
                return _clickSavePerson ?? (_clickSavePerson = new CommandHandler(() => SavePerson(), () => CanSavePerson));
            }
        }

        public ICommand? ClickCancel
        {
            get
            {
                return _clickCancel ?? (_clickCancel = new CommandHandler(() => Cancel(), () => { return true; }));
            }
        }

        public WindowEditClientViewModel()
        {
            IsEditedBankClient = new BankClient();
        }

        public WindowEditClientViewModel(IBankClient bankClient)
        {
            IsEditedBankClient = bankClient;
        }

        private bool CanSavePerson 
        { 
            get 
            {
                return true;
            } 
        }

        private void SavePerson()
        {
            OnSaveBankClient?.Invoke(IsEditedBankClient);
            OnExit?.Invoke();
        }

        private void Cancel()
        {
            OnExit?.Invoke();
        }

    }
}
