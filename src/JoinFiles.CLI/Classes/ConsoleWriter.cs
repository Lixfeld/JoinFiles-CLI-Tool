namespace JoinFiles.CLI.Classes
{
    internal class ConsoleWriter
    {
        private readonly bool isVerbose;

        public ConsoleWriter(bool verbose)
        {
            this.isVerbose = verbose;
        }

        public void Info(string message)
        {
            if (isVerbose)
            {
                Console.WriteLine(message);
            }
        }

        public void Warning(string message) => WriteColorLine(message, ConsoleColor.Yellow);

        public void Error(string message) => WriteColorLine(message, ConsoleColor.Red);

        public void Success(string message) => WriteColorLine(message, ConsoleColor.Green);

        private void WriteColorLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}