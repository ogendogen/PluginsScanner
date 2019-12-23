using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using PluginsScanner;

namespace PluginsScanner
{
	class Program
	{
		static void Main()
		{
			string filesDirectory = @"D:/files";
			string filesType = "*.memory";
			string[] lookupStrings = new string[3] {
				"amxmodx",
				"set_user_flags",
				"abcdefghijklmnopqrstu"
			};

			try
			{
				if (!Directory.Exists(filesDirectory))
				{
					Console.WriteLine($"Directory { filesDirectory } does not exist");
					Console.ReadLine();

					return;
				}

				List<Plugin> scannedPlugins = PluginsScanner.ScanPlugins(filesDirectory, filesType, lookupStrings);
				if (scannedPlugins.Count > 0)
				{
					foreach (var lookupString in lookupStrings)
					{
						var pluginsWithInfections = scannedPlugins.Where(plugin => plugin.InfectionOccurences.Any(infection => infection.FoundString.Contains(lookupString))).ToList();
						Console.WriteLine($"Results of '{ lookupString }' - { pluginsWithInfections.Count() } occurences:");
						foreach (var plugin in pluginsWithInfections)
						{
							foreach (var infection in plugin.InfectionOccurences)
							{
								Console.WriteLine($"\tFile: { plugin.Name } Line: { infection.LineNumber }");
							}
						}
						Console.WriteLine("\n");
					}

					Console.WriteLine($"Found {scannedPlugins.Count} possibly infected plugins.");
				}
				else
				{
					Console.WriteLine("No infections found");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception occured: {e.Message} ");
			}


			//string[] fileContent;
			//string fileName;
			//int lineIndex;
			//List<string> log = new List<string>();

			//if (!Directory.Exists(filesDirectory))
			//{
			//	Console.WriteLine("Directory {0} does not exist", filesDirectory);
			//	Console.ReadLine();

			//	return;
			//}

			//string[] filePaths = Directory.GetFiles(filesDirectory, filesType, SearchOption.TopDirectoryOnly);

			//foreach (string file in filePaths)
			//{
			//	if (!File.Exists(file))
			//	{
			//		continue;
			//	}

			//	fileContent = File.ReadAllLines(file);
			//	fileName = file.Substring(filesDirectory.Length + 1);
			//	lineIndex = 1;

			//	foreach (string line in fileContent)
			//	{
			//		foreach (string value in lookupStrings)
			//		{
			//			if (!line.Contains(value))
			//			{
			//				continue;
			//			}

			//			AddLog(fileName, lineIndex);
			//		}

			//		lineIndex++;
			//	}
			//}

			//PrintLog();

			//Console.Read();

			//void PrintLog()
			//{
			//	foreach (string lookup in lookupStrings)
			//	{
			//		Console.WriteLine("Results of '{0}' - {1} occurences:", lookup, log.Count);

			//		log.ForEach(l => { Console.WriteLine(l); });

			//		Console.WriteLine("\n");
			//	}

			//	Console.WriteLine("Found {0} possibly infected plugins.", log.Count);
			//}

			//void AddLog(string file, int line)
			//{
			//	log.Add("\tFile: " + file + " Line: " + line);
			//}
		}
	}
}