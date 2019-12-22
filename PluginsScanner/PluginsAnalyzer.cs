﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PluginsScanner
{
    public class PluginsAnalyzer
    {
        public string[] LookupStrings { get; set; }

        public IEnumerable<InfectionOccurence> AnalyzePlugins(List<Plugin> plugins)
        {
            foreach (var plugin in plugins)
            {
                string[] foundLines = plugin.PluginDump.Where(line => LookupStrings.Any(lookupString => line.Contains(lookupString))).ToArray();
                
                foreach (var foundLine in foundLines)
                {
                    yield return new InfectionOccurence
                    {
                        FileName = plugin.Name,
                        FoundString = foundLine,
                        LineNumber = Array.IndexOf(plugin.PluginDump, foundLine) + 1
                    };
                }
            }
        }
    }
}
