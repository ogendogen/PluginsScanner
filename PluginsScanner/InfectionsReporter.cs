using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsScanner
{
    public static class InfectionsReporter
    {
		public static void ReportInfections(string[] lookupStrings, List<Plugin> scannedPlugins, Progress<string> progress)
		{
			if (scannedPlugins.Count > 0)
			{
				foreach (var lookupString in lookupStrings)
				{
					var pluginsWithInfections = scannedPlugins.Where(plugin => plugin.InfectionOccurences.Any(infection => infection.FoundString.Contains(lookupString))).ToList();
					((IProgress<string>)progress).Report($"Results of '{ lookupString }' - { pluginsWithInfections.Count() } occurences:");
					foreach (var plugin in pluginsWithInfections)
					{
						foreach (var infection in plugin.InfectionOccurences)
						{
							((IProgress<string>)progress).Report($"\tFile: { plugin.Name } Line: { infection.LineNumber }");
						}
					}
					((IProgress<string>)progress).Report("\n");
				}

				((IProgress<string>)progress).Report($"Found {scannedPlugins.Count} possibly infected plugins.");
			}
			else
			{
				((IProgress<string>)progress).Report("No infections found");
			}
		}
    }
}
