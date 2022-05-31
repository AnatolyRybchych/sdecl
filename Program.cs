

using sdecl.ProjectCommands;
using System.Text.Json;

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
            commandManager.Commands.Add(new IEnumerableDirectoryAddCommand());

            commandManager.Execute("start", args);
            Console.WriteLine(JsonSerializer.Serialize(commandManager.CurrentData));
        }
    }
}
