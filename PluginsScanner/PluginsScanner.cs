using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsScanner
{
    public static class PluginsScanner
    {
		public static List<Plugin> ScanPlugins(string filesDirectory, string filesType, string[] lookupStrings, IProgress<string> progress = null)
		{
			List<Plugin> plugins = PluginsReader.GetPluginsFromDirectory(filesDirectory, filesType, progress).ToList();
			PluginsAnalyzer pluginsAnalyzer = new PluginsAnalyzer { LookupStrings = lookupStrings };
			List<Plugin> scannedPlugins = pluginsAnalyzer.AnalyzePlugins(plugins).ToList();
			return scannedPlugins;
		}
    }
}
