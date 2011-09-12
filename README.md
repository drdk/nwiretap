#About nwiretap
**NWiretap is a set of simple tools to monitor points of interest inside your .NET Applications**

Create a class with a set of instruments:

```c#
public class HomeController : Controller
{
    private static readonly IMeter Meter = Instrument.Meter(typeof(HomeController), "General performance", "Index hits", 3000);
    private static readonly IInvocationTimer Timer = Instrument.Timer(typeof(HomeController), "General performance", "Database fetch", 3000);
    private static readonly ILogger Logger = Instrument.Logger(typeof(HomeController), "General logging", "Log output", 20);
        
    public ActionResult Index()
    {
        Meter.Tick();
        var s = Timer.Time(() => GetStrings());

        Logger.Log("Index was hit");
        return View();
    }
}
```

The measurements can then be obtained as JSON by acessing /nwiretap (this url is configurable) on your application:

```js
[
   {
      "GroupName":"General performance",
      "Instruments":[
         {
            "InstrumentID":1,
            "InstrumentIdent":"Database fetch",
            "InstrumentType":"InvocationTimer",
            "ImplementorType":"HomeController",
            "InstrumentGroup":"General performance",
            "Measurement":{
               "Samples":[
                  {
                     "AverageInvokationTimeMs":0,
                     "MaxInvocationTimeMs":0,
                     "MinInvocationTimeMs":0
                  },
                  {
                     "AverageInvokationTimeMs":0,
                     "MaxInvocationTimeMs":0,
                     "MinInvocationTimeMs":0
                  },
                  {
                     "AverageInvokationTimeMs":0,
                     "MaxInvocationTimeMs":0,
                     "MinInvocationTimeMs":0
                  },
                  {
                     "AverageInvokationTimeMs":0,
                     "MaxInvocationTimeMs":0,
                     "MinInvocationTimeMs":0
                  },
                  {
                     "AverageInvokationTimeMs":0,
                     "MaxInvocationTimeMs":0,
                     "MinInvocationTimeMs":0
                  },
                  {
                     "AverageInvokationTimeMs":0,
                     "MaxInvocationTimeMs":0,
                     "MinInvocationTimeMs":0
                  },
                  {
                     "AverageInvokationTimeMs":0,
                     "MaxInvocationTimeMs":0,
                     "MinInvocationTimeMs":0
                  }
               ],
               "CurrentFrequency":0,
               "Ticks":1
            }
         },
         {
            "InstrumentID":0,
            "InstrumentIdent":"Index hits",
            "InstrumentType":"Meter",
            "ImplementorType":"HomeController",
            "InstrumentGroup":"General performance",
            "Measurement":{
               "CurrentFrequency":0,
               "Ticks":1
            }
         }
      ]
   },
   {
      "GroupName":"General logging",
      "Instruments":[
         {
            "InstrumentID":2,
            "InstrumentIdent":"Log output",
            "InstrumentType":"Logger",
            "ImplementorType":"HomeController",
            "InstrumentGroup":"General logging",
            "Measurement":{
               "Entries":[
                  {
                     "Line":"Index was hit",
                     "Created":"00:06:03"
                  }
               ]
            }
         }
      ]
   }
]
```
