

namespace sdecl
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandManager commandManager = new CommandManager(new RootCommandToken(args));

            commandManager.Commands.Add(new RootCommand());
            commandManager.Commands.Add(new CacheCommand());
            commandManager.Commands.Add(new DirsCommand());
            commandManager.Commands.Add(new IEnumerableAtCommand());

            commandManager.Execute("start", args);
            Console.WriteLine(commandManager.CurrentData);
        }
    }
}
