using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Instruments.Logger
{
    public interface ILogger
    {
        void Log(string message);
    }
}
