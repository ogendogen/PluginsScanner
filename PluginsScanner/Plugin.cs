using System;
using System.Collections.Generic;
using System.Text;

namespace PluginsScanner
{
    public class Plugin
    {
        public string Name { get; set; }
        public string[] PluginDump { get; set; }
        public List<InfectionOccurence> InfectionOccurences { get; set; }

        public Plugin()
        {
            InfectionOccurences = new List<InfectionOccurence>();
        }
    }
}
