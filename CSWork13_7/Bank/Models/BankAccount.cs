using CSWork12_5.Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSWork12_5.Bank.Models
{
    public class BankAccount : IBankAccount, ISerializable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private float _amount;
        public float Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public BankAccount() : this(0) { }

        public BankAccount(float amount)
        {
            Amount = amount;
        }

        public BankAccount(SerializationInfo info, StreamingContext context)
        {
            Amount = (float)info.GetValue(nameof(Amount), typeof(float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Amount), Amount);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
