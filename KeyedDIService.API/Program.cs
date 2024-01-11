using KeyedDIService.API.LifetimeServices;
using KeyedDIService.API.LifetimeServices.Interfaces;
using KeyedDIService.API.Services;
using KeyedDIService.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedScoped<IProcessDataService, DataProcessorA>("ServiceA");
builder.Services.AddKeyedScoped<IProcessDataService, DataProcessorB>("ServiceB");
builder.Services.AddKeyedScoped<IProcessDataService, DataProcessorC>("ServiceC");


builder.Services.AddSingleton<IOurSingletonService, OurLifeTimeService>();
builder.Services.AddTransient<IOutTransientService, OurLifeTimeService>();
builder.Services.AddScoped<IOurScopedService, OurLifeTimeService>();


var app = builder.Build();



app.MapGet("/printResult",
        (IOurSingletonService singletonService,
            IOutTransientService transientService1, IOutTransientService transientService2,
            IOurScopedService scopedService1, IOurScopedService scopedService2) =>
        {
            return $"|Singleton| ==> {singletonService.PrintResult()} \n" + 
                    $"|Scoped-1| ==> {scopedService1.PrintResult()} \n"+
                    $"|Scoped-2| ==> {scopedService2.PrintResult()} \n" +
                    $"|Transient-1| ==> {transientService1.PrintResult()} \n" +
                    $"|Transient-2| ==> {transientService2.PrintResult()}";
        })
     .WithName("PrintResult");

app.MapGet("/processData", 
        ([FromKeyedServices("ServiceA")] IProcessDataService dataProcessorA,
            [FromKeyedServices("ServiceB")] IProcessDataService dataProcessorB,
            [FromKeyedServices("ServiceC")] IProcessDataService dataProcessorC) => dataProcessorB.ProcessData(Guid.NewGuid().ToString()))
    .WithName("DataProcessor");

app.Run();


