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