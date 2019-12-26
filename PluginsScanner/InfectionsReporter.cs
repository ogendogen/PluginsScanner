using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsScanner
{
    public static class InfectionsReporter
    {
		public static void ReportInfections(string[] lookupStrings, List<Plugin> scannedPlugins, IProgress<string> progress)
		{
			if (scannedPlugins.Count > 0)
			{
				int infectedPluginsAmount = 0;
				foreach (var lookupString in lookupStrings)
				{
					var pluginsWithInfections = scannedPlugins.Where(plugin => plugin.InfectionOccurences.Any(infection => infection.FoundString.Contains(lookupString))).ToList();
					infectedPluginsAmount += pluginsWithInfections.Count;
					progress.Report($"Results of '{ lookupString }' - { pluginsWithInfections.Count() } occurences:");
					foreach (var plugin in pluginsWithInfections)
					{
						foreach (var infection in plugin.InfectionOccurences)
						{
							progress.Report($"\tFile: { plugin.Name } Line: { infection.LineNumber }");
						}
					}
					progress.Report("\n");
				}

				progress.Report($"Found { infectedPluginsAmount } possibly infected plugins.");
			}
			else
			{
				progress.Report("No infections found");
			}
		}
    }
}
