namespace MonkeyFinder.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged; //This is the EventHandler which needs to be raised when change in Property is detected

    bool isBusy;
    bool isNotBusy;
    string title;
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if(isBusy== value)
            {
                return;
            }
            isBusy = value;
            OnPropertychanged(nameof(IsBusy));
            OnPropertychanged(nameof(IsNotBusy));
        }
    }
    public bool IsNotBusy => !IsBusy;//We also need to update for IsNotBusy when IsBusy Changes so we call it in IsBusy Property only

    public string Title
    {
        get => title;
        set
        {
            if(title== value)
            {
                return;
            }
            title = value;
            OnPropertychanged(nameof(Title));
        }
    }
    //We dont even have to pass nameof everytime we can use compiler Optimizer setting
    public void OnPropertychanged([CallerMemberName]string name=null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
