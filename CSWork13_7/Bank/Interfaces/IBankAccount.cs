using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace CSWork12_5.Bank.Interfaces
{
    public interface IBankAccount: INotifyPropertyChanged
    {
        public float Amount { get; set; }
    }
}
