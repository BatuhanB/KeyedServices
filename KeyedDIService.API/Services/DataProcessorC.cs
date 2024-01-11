using KeyedDIService.API.Services.Interfaces;

namespace KeyedDIService.API.Services;

public class DataProcessorC: IProcessDataService
{
    public string ProcessData(string data)
    {
        return $"{data} has been processed with Service |C|";
    }
}