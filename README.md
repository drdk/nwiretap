#NWiretap
**A set of simple instruments to track whats going on inside your .NET applications**

To create a Meter-type instrument:
```js
//Create a Meter with the name "Some counter" and a sample size of 3000ms
private static readonly IMeter Ticker = Instrument.Ticker("Some counter", 3000); //These should be kept alive as long as possible
Ticker.Tick(); //Record a tick

//Create an InvocatonTimer type instrument:
private static readonly IInvocationTimer Timer = Instrument.Timer("Some timer", 3000);

var s = Timer.Time(() => 	{
					return _someRepository.GetStuffFromDatabase();
				});

//Create a simple logger:
private static readonly ILogger Logger = Instrument.Logger("SomeLogger", 20);

Logger.Log("Hey yooo");

```