

using CommandManager;
using sdecl.ProjectCommands;
using System.Text.Json;

namespace sdecl
{
    class Program
    {
        static void Main(string[] args)
        {
            Sdecl sdecl = Sdecl.Get();

            CommandManager.CommandManager commandManager = new CommandManager.CommandManager(new RootCommandToken(args, sdecl));

            //for all
            //commandManager.Commands.Add(new TypeCommand("type"));
            commandManager.Commands.Add(new CommandsCommand("commands"));

            //for RootCommandToken
            commandManager.Commands.Add(new RootCommand("start"));

            //for all enumerables
            commandManager.Commands.Add(new IEnumerableAtCommand("at"));
            commandManager.Commands.Add(new IEnumerableClearCommand("clear"));

            //for sdecl
            commandManager.Commands.Add(new StackCommand("stack"));
            commandManager.Commands.Add(new SelectStackCommand("select"));
            commandManager.Commands.Add(new DeleteStackCommand("delete"));

            //for Stack
            commandManager.Commands.Add(new StackDirsCommand("dirs"));
            commandManager.Commands.Add(new StackFilesCommand("files"));

            //for directories enumerable
            commandManager.Commands.Add(new IEnumerableDirectoryAddCommand("add"));
            commandManager.Commands.Add(new IEnumerableSaveCommand<ObservableDirectory>("save", (e =>
            {
                sdecl.CurrStack.ObservableDirectories = e.ToList();
                sdecl.CurrStack.Serialize();
            })));

            // for files enumerable
            commandManager.Commands.Add(new IEnumerableFilesAddCommand("add"));
            commandManager.Commands.Add(new IEnumerableSaveCommand<ObservableFile>("save", (e =>
            {
                sdecl.CurrStack.ObservableFiles = e.ToList();
                sdecl.CurrStack.Serialize();
            })));

            commandManager.Execute("start", args);
            Console.WriteLine(new CommandResonseSerializer().Serialize(commandManager.CurrentData));
        }
    }
}
