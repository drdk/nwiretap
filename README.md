#NWiretap
**A set of simple instruments to track whats going on inside your .NET applications**

A primitive example of usage from an ASP.NET MVC Controller

```c#
public class HomeController : Controller
{
    private static readonly IMeter Ticker = Instrument.Ticker("Some counter", 3000);
    private static readonly IInvocationTimer Timer = Instrument.Timer("Some timer", 3000);
    private static readonly ILogger Logger = Instrument.Logger("SomeLogger", 20);
        
    public ActionResult Index()
    {
        Ticker.Tick();
        var s = Timer.Time(() =>
                               {
                                   return Database.GetSomeStuff();
                               });

        Logger.Log("Index was hit");
        return View();
    }
}
```

The measurements can then be obtained as JSON by calling the /nwiretap (this url is configurable) on your application:

```js
[
-{
InstrumentID: 0
InstrumentIdent: "Some counter"
InstrumentType: "Meter"
-Measurement: {
CurrentFrequency: 1
Ticks: 4
}
}
-{
InstrumentID: 1
InstrumentIdent: "Some timer"
InstrumentType: "InvocationTimer"
-Measurement: {
-Samples: [
-{
AverageInvokationTimeMs: 299
MaxInvocationTimeMs: 299
MinInvocationTimeMs: 299
}
]
CurrentFrequency: 1
Ticks: 4
}
}
-{
InstrumentID: 2
InstrumentIdent: "SomeLogger"
InstrumentType: "Logger"
-Measurement: {
-Entries: [
-{
Line: "Index was hit"
Created: "2011-09-11T17:01:23.6554291+02:00"
}
-{
Line: "Index was hit"
Created: "2011-09-11T17:01:23.1383995+02:00"
}
-{
Line: "Index was hit"
Created: "2011-09-11T17:01:22.5263645+02:00"
}
-{
Line: "Index was hit"
Created: "2011-09-11T17:01:20.6772587+02:00"
}
]
}
}
]
```