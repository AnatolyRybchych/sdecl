using CommandManager;

namespace sdecl
{
    internal class ListStacksCommand : CommandWithTypeOrDerivative<Sdecl>
    {
        public ListStacksCommand(string commandName) : base(commandName)
        {
        }

        public override string Help => "returns list of sdecl stacks";

        public override object ExecuteCommand(Sdecl input, CommandManager.CommandManager mgr)
        {
            return new ListStacksCommandResponse(Stack.GetStacks());
        }

        private class ListStacksCommandResponse
        {
            public string[] Stacks { get; private set; }
            public ListStacksCommandResponse(string[] stacks)
            {
                Stacks = stacks;
            }

            public override string ToString()
            {
                return new CommandResonseSerializer().Serialize(Stacks);
            }
        }
    }
}
