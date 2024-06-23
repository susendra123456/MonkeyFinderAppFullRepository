using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel2
{
    MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new();
    //public Command GetMonkeysCommand { get; }
    public MonkeysViewModel(MonkeyService service)
    {
        Title = "Monkey Finder";
        this.monkeyService = service;
       // GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if(IsBusy) return;
        try
        {
            IsBusy = true;
            //var monkeys = await monkeyService.GetMonkeys();
             var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            List<Monkey> monkeyList = new List<Monkey>();
            monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
            if (Monkeys.Count != 0)
            {
                Monkeys.Clear();
            }
            foreach(var monkey in monkeyList)
            {
                Monkeys.Add(monkey);

            }
        }catch(Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Unable to get Monkeys: {ex.Message}", "OK");
           //This is to collect single val from USer
            var stringVal = await Shell.Current.DisplayPromptAsync("Prompt","Please enter the Secret Code Received","OK","Cancel","......",6,Keyboard.Numeric);
            await Shell.Current.DisplayAlert("Alert!!!", $"U Entered the below Number{int.Parse(stringVal)}", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
