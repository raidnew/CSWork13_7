using CSWork12_5.Bank.Interfaces;
using CSWork13_7.Bank.Logger;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CSWork12_5.Bank.Models
{
    public class BankClient : IBankClient
    {
        private int _id = -1;
        private string _firstName;
        private string _lastName;
        private string _thirdName;

        public int ID 
        {
            get => _id;  
            set
            {
                if (_id == -1) _id = value;
            }
        }

        public string FirstName 
        { 
            get 
            {
                return _firstName;
            }
            set 
            { 
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            } 
        }

        public string LastName 
        { 
            get 
            {
                return _lastName;
            }
            set 
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            } 
        }

        public string ThirdName
        { 
            get 
            {
                return _thirdName;
            }
            set 
            {
                _thirdName = value;
                OnPropertyChanged(nameof(ThirdName));
            } 
        }
        public BankAccount Account { get; set; }
        public BankAccount DepositAccount { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public BankClient()
        {
            ID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            ThirdName = string.Empty;
            Account = new BankAccount();
            DepositAccount = new BankAccount();
            Init();
        }

        public BankClient(SerializationInfo info, StreamingContext context)
        {
            ID = (int)info.GetValue(nameof(ID), typeof(int));
            FirstName = (string)info.GetValue(nameof(FirstName), typeof(string));
            LastName = (string)info.GetValue(nameof(LastName), typeof(string));
            ThirdName = (string)info.GetValue(nameof(ThirdName), typeof(string));
            Account = (BankAccount)info.GetValue(nameof(Account), typeof(BankAccount));
            DepositAccount = (BankAccount)info.GetValue(nameof(DepositAccount), typeof(BankAccount));
            Init();
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(ID), ID);
            info.AddValue(nameof(FirstName), FirstName);
            info.AddValue(nameof(LastName), LastName);
            info.AddValue(nameof(ThirdName), ThirdName);
            info.AddValue(nameof(Account), Account);
            info.AddValue(nameof(DepositAccount), DepositAccount);
        }

        public bool TransferMoney(IBankAccount account, int amount)
        {
            return false;
        }

        public bool ReceiveMoney(IBankAccount account, int amount)
        {
            return false;
        }

        private void Init()
        {
            Account.PropertyChanged += AccountChanged;
            DepositAccount.PropertyChanged += DepositAccountChanged;
        }

        private void AccountChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Account));
        }

        private void DepositAccountChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DepositAccount));
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
