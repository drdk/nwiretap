using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Measurement
{
    [AttributeUsage(AttributeTargets.Class)]
    public class VisualizationHandlerAttribute : Attribute
    {
        public string Visualizer { get; private set; }
        public VisualizationHandlerAttribute(string visualizer)
        {
            Visualizer = visualizer;
        }
    }
}
