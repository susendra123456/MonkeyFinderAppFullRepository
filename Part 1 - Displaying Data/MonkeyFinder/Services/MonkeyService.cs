using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    List<Monkey> monkeys = new();
    HttpClient httpClient;
    public async Task<List<Monkey>> GetMonkeys()
    {
        httpClient= new();
        string uri = "https://montemango.com/monkeys.json";
        HttpResponseMessage response = await httpClient.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            
            //If u are getting data from Local Folder then use below things]
            //Create a Stream from the File Location
            //Then create a Reader from the dtream
            //Then Read data and store it
            //Then deserialize the Data and Get required data from it
           /* var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            List<Monkey> monkeyList = new List<Monkey>();
            monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);*/

        }
        return monkeys;
    }
}
