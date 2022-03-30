using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinFiles.CLI.Classes
{
    internal class Options
    {
        [Value(0, MetaName = "input-directory", Required = true, HelpText = "Path of the directory with input files.")]
        public string InputDirectory { get; set; }

        [Value(1, MetaName = "output-file", Required = true, HelpText = "Path for the output file including file extension.")]
        public string OutputFile { get; set; }

        [Option('a', "all-directories", MetaValue = "BOOL", HelpText = "Includes the current directory and all its subdirectories in a search operation.")]
        public bool AllDirectories { get; set; }

        [Option("extension", HelpText = "Filter the input files by extension.")]
        public string Extension { get; set; }

        [Option("separator-file", HelpText = "Path of the file which should be used as a separator.")]
        public string SeparatorFile { get; set; }

        [Option('o', "overwrite", MetaValue = "BOOL", HelpText = "Overwrite the output file, if it already exists.")]
        public bool OverwriteOutput { get; set; }

        [Option("skip", Default = 0, MetaValue = "INT", HelpText = "Skip the first {count} files ordered by name.")]
        public int SkipCount { get; set; }

        [Option("take", MetaValue = "NULLABLE<INT>", HelpText = "Take a maximum of {count} files.")]
        public int? TakeCount { get; set; }

        [Option('v', "verbose", MetaValue = "BOOL", HelpText = "Show verbose messaging.")]
        public bool Verbose { get; set; }
    }
}