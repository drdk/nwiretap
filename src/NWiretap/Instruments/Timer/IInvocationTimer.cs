using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NWiretap.Instruments.Timer
{
    public interface IInvocationTimer
    {
        TResult Time<TResult>(Func<TResult> func);
        void Time(Action act);
    }
}