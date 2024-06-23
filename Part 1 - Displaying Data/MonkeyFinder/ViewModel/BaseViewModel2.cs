using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.ViewModel
{
    public partial class BaseViewModel2 : ObservableObject
    {
        //this is another way of calling INotifyPropertyChanged where Observable class is built in and generates source code and it implements INotifyPropertyChanged also
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;

    }
}
