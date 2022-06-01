using CommandManager;

namespace sdecl.ProjectCommands
{
    internal class StackAllCommand : CommandWithTypeOrDerivative<Stack>
    {
        public StackAllCommand(string commandName) : base(commandName)
        {
        }

        public override string Help => "returns all file in stack";

        public override object ExecuteCommand(Stack input, CommandManager.CommandManager mgr)
        {
            return input.GetFiles();
        }
    }
}
