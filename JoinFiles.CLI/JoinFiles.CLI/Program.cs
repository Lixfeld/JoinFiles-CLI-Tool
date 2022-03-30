using CommandLine;
using JoinFiles.CLI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinFiles.CLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
            {
                ConsoleWriter consoleWriter = new ConsoleWriter(options.Verbose);
                try
                {
                    JoinCommand joinCommand = new JoinCommand(options, consoleWriter);
                    joinCommand.Execute();
                }
                catch (Exception ex)
                {
                    consoleWriter.Error(ex.Message);
                }
            });
        }
    }
}