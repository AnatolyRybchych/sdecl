

using sdecl.ProjectCommands;
using System.Text.Json;

namespace sdecl
{
    class Program
    {
        static void Main(string[] args)
        {
            sdecl sdecl = new sdecl();

            CommandManager commandManager = new CommandManager(new RootCommandToken(args, sdecl));

            //for RootCommandToken
            commandManager.Commands.Add(new RootCommand("start"));

            //for all enumerables
            commandManager.Commands.Add(new IEnumerableAtCommand("at"));

            //for sdecl
            commandManager.Commands.Add(new CacheCommand("cache"));

            //for Cache
            commandManager.Commands.Add(new CacheDirsCommand("dirs"));
            commandManager.Commands.Add(new CacheFilesCommand("files"));
            commandManager.Commands.Add(new IEnumerableDirectoryAddCommand("add"));

            //for directories enumerable
            commandManager.Commands.Add(new IEnumerableSaveCommand<ObservableDirectory>("save", (e =>
            {
                sdecl.Cache.Settings.ObservableDirectories = e.ToList();
                sdecl.Cache.Serialize();
            })));

            // for files enumerable
            commandManager.Commands.Add(new IEnumerableFilesAddCommand("add"));
            commandManager.Commands.Add(new IEnumerableSaveCommand<ObservableFile>("save", (e =>
            {
                sdecl.Cache.Settings.ObservableFiles = e.ToList();
                sdecl.Cache.Serialize();
            })));




            commandManager.Execute("start", args);
            Console.WriteLine(new CommandResonseSerializer().Serialize(commandManager.CurrentData));
        }
    }
}
