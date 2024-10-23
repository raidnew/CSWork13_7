using CSWork12_5.Bank.Interfaces;
using CSWork12_5.Bank.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task.Common;

namespace CSWork12_5.Bank.ViewModels;

public class WindowEditBankAccountViewModel : INotifyPropertyChanged
{
    public Action OnExit;
    public Action<IBankClient, IBankAccount, IBankClient, IBankAccount, float> OnTransferMoney;

    private ICommand? _clickTransfer;
    private ICommand? _clickCancel;
    private ICommand? _clickAccount;
    private ICommand? _clickAccountTarget;

    public ICommand ClickAccount
    {
        get
        {
            return _clickAccount ?? (_clickAccount = new CommandHandlerParam((account) => SelectAccount(account), () => { return true; }));
        }
    }

    public ICommand ClickAccountTarget
    {
        get
        {
            return _clickAccountTarget ?? (_clickAccountTarget = new CommandHandlerParam((account) => SelectAccountTarget(account), () => { return true; }));
        }
    }

    public ICommand ClickTransfer
    {
        get
        {
            return _clickTransfer ?? (_clickTransfer = new CommandHandler(() => Transfer(), () => CanTransfer));
        }
    }

    public ICommand ClickCancel
    {
        get
        {
            return _clickCancel ?? (_clickCancel = new CommandHandler(() => Cancel(), () => { return true; }));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public ReadOnlyObservableCollection<IBankClient>? BanksClients { get; set; }
    public IBankClient? CurrentBanksClient { get; set; }

    private IBankClient _selectedBankClient;
    public IBankClient? SelectedBanksClient {
        get { return _selectedBankClient; } 
        set
        {
            _selectedBankClient = value;
            OnPropertyChanged(nameof(SelectedBanksClient));
        }
    }
    public IBankAccount? SelectedDestinationAccount { get; set; }
    public IBankAccount? SelectedSourceAccount { get; set; }

    public float TransferAmount { get; set; }

    private bool CanTransfer
    {
        get
        {
            return SelectedBanksClient != null && SelectedDestinationAccount != null && TransferAmount > 0 && TransferAmount <= SelectedDestinationAccount.Amount;
        }
    }

    private void SelectAccount(object account)
    {
        IBankAccount bankAccount = (IBankAccount)account;
        SelectedDestinationAccount = bankAccount;
    }

    private void SelectAccountTarget(object account)
    {
        SelectedSourceAccount = (IBankAccount)account;
    }

    private void Transfer()
    {
        OnTransferMoney?.Invoke(CurrentBanksClient, SelectedDestinationAccount, SelectedBanksClient, SelectedSourceAccount, TransferAmount);
        OnExit?.Invoke();
    }

    private void Cancel()
    {
        OnExit?.Invoke();
    }

    private void OnPropertyChanged([CallerMemberName] string name = null)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
    }

}
