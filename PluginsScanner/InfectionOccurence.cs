using System;
using System.Collections.Generic;
using System.Text;

namespace PluginsScanner
{
    public class InfectionOccurence
    {
        public string FoundString { get; set; }
        public int LineNumber { get; set; }

        public override bool Equals(object obj)
        {
            return obj is InfectionOccurence occurence &&
                   FoundString == occurence.FoundString;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FoundString);
        }
    }
}
