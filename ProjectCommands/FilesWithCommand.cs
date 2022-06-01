using CommandManager;

namespace sdecl.ProjectCommands
{
    internal class FilesWithCommand : CommandWithTypeOrDerivative<IEnumerable<ObservableFile>>
    {
        

        public StringCommandArgument Substring { get; private set; }
        public FlagArgument ForName { get; private set; }

        public override string Help => "returns subcollection where ( path or name if -n ) is contains substring";

        public FilesWithCommand(string commandName) : base(commandName)
        {
            Substring = new StringCommandArgument(true, "substring", ".+");
            ForName = new FlagArgument("name", "-n");

            Signeture.Args.Add(Substring);
            Signeture.Args.Add(ForName);
        }

        public override object ExecuteCommand(IEnumerable<ObservableFile> input, CommandManager.CommandManager mgr)
        {
            if (ForName.Value)
            {
                return input.Where(file => Path.GetFileName(file.Path).Contains(Substring.Value));
            }
            else
            {
                return input.Where(file => file.Path.Contains(Substring.Value));
            }
        }
    }
}
