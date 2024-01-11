using KeyedDIService.API.LifetimeServices.Interfaces;

namespace KeyedDIService.API.LifetimeServices;

public class OurLifeTimeService : IOutTransientService, IOurSingletonService,IOurScopedService
{
    private readonly string _guidValue;

    public OurLifeTimeService()
    {
        _guidValue = Guid.NewGuid().ToString();
    }

    public string PrintResult()
    {
        return _guidValue;
    }
}