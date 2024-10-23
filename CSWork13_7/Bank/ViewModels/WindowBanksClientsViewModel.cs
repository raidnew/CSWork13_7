using CSWork12_5.Bank.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Task.Common;

namespace CSWork12_5.Bank.ViewModels;

public class WindowBanksClientsViewModel : INotifyPropertyChanged
{
    public Action<IBankClient>? OnClickEditBankClient;
    public Action<IBankClient>? OnClickTransfer;
    public Action? OnClickAddBankClient;

    public event PropertyChangedEventHandler? PropertyChanged;
    public ReadOnlyObservableCollection<IBankClient> BankClients { get; set; }
    public IBankClient? SelectedBankClient { get; set; }

    private ICommand? _clickAddBankClient;
    private ICommand? _clickEditBankClient;
    private ICommand? _clickTransfer;

    public ICommand ClickAddBankClient
    {
        get
        {
            return _clickAddBankClient ?? (_clickAddBankClient = new CommandHandler(() => AddBankClient(), () => CanAddBankClient));
        }
    }

    public ICommand ClickEditBankClient
    {
        get
        {
            return _clickEditBankClient ?? (_clickEditBankClient = new CommandHandler(() => EditBankClient(), () => HasSelectedClient));
        }
    }

    public ICommand ClickTransfer
    {
        get
        {
            return _clickTransfer ?? (_clickTransfer = new CommandHandler(() => Transfer(), () => HasSelectedClient));
        }
    }

    private bool CanAddBankClient
    {
        get{
            return true;
        }
    }

    private bool HasSelectedClient
    {
        get
        {
            return SelectedBankClient != null;
        }
    }

    private void AddBankClient()
    {
        OnClickAddBankClient?.Invoke();
    }

    private void EditBankClient()
    {
        OnClickEditBankClient?.Invoke(SelectedBankClient);
    }

    private void Transfer()
    {
        OnClickTransfer?.Invoke(SelectedBankClient);
    }
}
