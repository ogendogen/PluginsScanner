using System;
using System.Collections.Generic;
using System.Text;

namespace PluginsScanner
{
    public class InfectionOccurence
    {
        public string FileName { get; set; }
        public string FoundString { get; set; }
        public int LineNumber { get; set; }
    }
}
