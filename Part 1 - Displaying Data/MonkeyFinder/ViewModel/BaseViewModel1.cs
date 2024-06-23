using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.ViewModel
{
    [INotifyPropertyChanged]
    public partial class BaseViewModel1
    {
        //If u are using INotifyPropertyChanged as Attribute then from CommunityToolkit.MVVM Provides Source Generators which will take care of all the Event Handling and Code Generation so u need to make it partial class

        bool isBusy;
        string title;
    }
}
