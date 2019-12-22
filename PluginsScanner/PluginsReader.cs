using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PluginsScanner
{
    public static class PluginsReader
    {
        public static IEnumerable<Plugin> GetPluginsFromDirectory(string directory, string matchPattern = "*.memory")
        {
            string[] files = Directory.GetFiles(directory, matchPattern);
            foreach (var file in files)
            {
                yield return new Plugin
                { 
                    Name = Path.GetFileNameWithoutExtension(file),
                    PluginDump = File.ReadAllLines(file)
                };
            }
        }
    }
}
