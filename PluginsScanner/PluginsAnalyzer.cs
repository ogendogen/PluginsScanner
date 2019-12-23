using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PluginsScanner
{
    public class PluginsAnalyzer
    {
        public string[] LookupStrings { get; set; }

        public List<Plugin> AnalyzePlugins(List<Plugin> plugins)
        {
            foreach (var plugin in plugins)
            {
                string[] foundLines = plugin.PluginDump.Where(line => LookupStrings.Any(lookupString => line.Contains(lookupString))).ToArray();
                
                foreach (var foundLine in foundLines)
                {
                    plugin.InfectionOccurences.Add(new InfectionOccurence
                    {
                        FoundString = foundLine,
                        LineNumber = Array.IndexOf(plugin.PluginDump, foundLine) + 1
                    });
                }
            }

            return plugins;
        }
    }
}
