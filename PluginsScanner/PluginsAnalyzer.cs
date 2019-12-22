using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PluginsScanner
{
    public class PluginsAnalyzer
    {
        public List<string> LookupStrings { get; set; }
        public string FilesType { get; set; }

        public IEnumerable<InfectionOccurence> AnalyzePlugins(List<Plugin> plugins)
        {
            foreach (var plugin in plugins)
            {
                string[] lines = plugin.PluginDump.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                string[] foundLines = lines.Where(line => LookupStrings.Any(lookupString => line.Contains(lookupString))).ToArray();
                
                foreach (var foundLine in foundLines)
                {
                    yield return new InfectionOccurence{ FoundString = foundLine, LineNumber = Array.IndexOf(lines, foundLine + 1)};
                }
            }
        }
    }
}
