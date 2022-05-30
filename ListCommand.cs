using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class ListCommand<T> : Command where T : Command, new()
    {
        private Command[] commands;
        public override Command[] Commands => commands;

        public override string Type => $"List<{new T().Type}>";

        public override string Help => $"List<{new T().Type}> contains {Elements.Count} elements\nhelp {new T().Type} :\n{new T().Help}";

        public override string StringRepresentation => String.Join("\n\n", Elements.Select(el => el.StringRepresentation));

        private string commandText;
        public override string CommandText => commandText;

        public List<T> Elements { get; set; }

        public ListCommand()
        {
            commands = new Command[]{
                new AddCommand(),
            };
            Elements = new List<T>();
            this.commandText = "list";
        }

        public ListCommand(string commandText, List<T> elements)
        {
            commands = new Command[]{
                new AddCommand(),
            };
            Elements = elements;
            this.commandText = commandText;
        }

        protected class AddCommand : ListCommand<T>
        {
            public AddCommand() : base("add", new List<T>()) {}

            public override void _Execute(ArgumentProvider args, Cache cache, Command previous)
            {
                var listCmd = previous as ListCommand<T>;
                if (listCmd == null) throw new Exception("add is command for object List<type>");

                this.Elements = listCmd.Elements;

                this.Elements.Add((T)new T().FromArg(args));
            }
        }
    }
}
