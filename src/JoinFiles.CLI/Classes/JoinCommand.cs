using System.Text;

namespace JoinFiles.CLI.Classes
{
    internal class JoinCommand
    {
        private readonly Options options;
        private readonly ConsoleWriter consoleWriter;

        public JoinCommand(Options options, ConsoleWriter consoleWriter)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.consoleWriter = consoleWriter ?? throw new ArgumentNullException(nameof(consoleWriter));
        }

        private bool Validate(out string separator)
        {
            separator = null;
            if (File.Exists(options.OutputFile) && !options.OverwriteOutput)
            {
                consoleWriter.Warning("The output file already exists.");
                return false;
            }

            if (options.SeparatorFile != null)
            {
                if (!File.Exists(options.SeparatorFile))
                {
                    consoleWriter.Warning("The separator file was not found.");
                    return false;
                }
                consoleWriter.Info("read: " + options.SeparatorFile);
                separator = File.ReadAllText(options.SeparatorFile);
            }
            return true;
        }

        public void Execute()
        {
            if (!Validate(out string separator))
                return;

            string searchPattern = "*.*";
            if (options.Extension != null)
            {
                // Allow extension with and without a dot
                searchPattern = "*." + options.Extension.TrimStart('.');
            }

            SearchOption searchOption = options.AllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var inputFiles = Directory.GetFiles(options.InputDirectory, searchPattern, searchOption).OrderBy(x => Path.GetFileName(x));

            var filtredFiles = inputFiles.Skip(options.SkipCount);
            if (options.TakeCount.HasValue)
            {
                filtredFiles = filtredFiles.Take(options.TakeCount.Value);
            }

            string[] filesToJoin = filtredFiles.ToArray();
            if (filesToJoin.Length == 0)
            {
                consoleWriter.Warning("No files to join.");
                return;
            }

            consoleWriter.Info("Total number of files: " + filesToJoin.Length);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filesToJoin.Length; i++)
            {
                if (i > 0 && separator != null)
                {
                    // Add separator between files (not at the start or end)
                    sb.AppendLine(separator);
                }

                string file = filesToJoin[i];
                consoleWriter.Info("read: " + file);
                string content = File.ReadAllText(file);

                sb.AppendLine(content);
            }

            consoleWriter.Info("write: " + options.OutputFile);
            File.WriteAllText(options.OutputFile, sb.ToString());
            consoleWriter.Success("File was successfully created: " + options.OutputFile);
        }
    }
}