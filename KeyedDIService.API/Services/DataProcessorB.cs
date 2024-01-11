using KeyedDIService.API.Services.Interfaces;

namespace KeyedDIService.API.Services;

public class DataProcessorB : IProcessDataService
{
    public string ProcessData(string data)
    {
        return $"{data} has been processed with Service |B|";
    }
}