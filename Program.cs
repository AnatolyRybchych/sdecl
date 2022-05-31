

using sdecl.ProjectCommands;
using System.Text.Json;

namespace sdecl
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandManager commandManager = new CommandManager(new RootCommandToken(args));

            commandManager.Commands.Add(new RootCommand("start"));
            commandManager.Commands.Add(new CacheCommand("cache"));
            commandManager.Commands.Add(new CacheDirsCommand("dirs"));
            commandManager.Commands.Add(new IEnumerableAtCommand("at"));
            commandManager.Commands.Add(new IEnumerableDirectoryAddCommand("add"));
            commandManager.Commands.Add(new CacheFilesCommand("files"));

            commandManager.Execute("start", args);
            Console.WriteLine(new CommandResonseSerializer().Serialize(commandManager.CurrentData));
        }
    }
}
