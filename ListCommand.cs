using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class ListCommand<T> : Command where T : Command, new()
    {
        public override Command[] Commands { get; }

        public event Action<T>? Appended;

        public override string Type => $"List<{new T().Type}>";

        public override string Help => $"List<{new T().Type}> contains {Elements.Count} elements\nhelp {new T().Type} :\n{new T().Help}";

        public override string StringRepresentation => String.Join("\n\n", Elements.Select(el => el.StringRepresentation));

        private string commandText;
        public override string CommandText => commandText;

        public List<T> Elements { get; set; }

        public ListCommand()
        {
            Commands = new Command[]{
                new AddCommand(),
                new AtCommand(),
            };
            Elements = new List<T>();
            this.commandText = "list";
        }

        public ListCommand(string commandText, List<T> elements):this()
        {
            Elements = elements;
            this.commandText = commandText;
        }

        protected class AddCommand : Command
        {
            public override Command[] Commands => throw new Exception("UNREACHABLE");

            public override string Type => throw new Exception("UNREACHABLE");

            public override string Help => throw new Exception("UNREACHABLE");

            public override string StringRepresentation => throw new Exception("UNREACHABLE");

            public override Command RefCommandCommand => List;

            public override string CommandText => "add";

            ListCommand<T>? list; 
            public ListCommand<T> List
            {
                get => list ?? new ListCommand<T>();
                set => list = value;
            }

            public override void _Execute(ArgumentProvider args, ref object? context, Command previous)
            {
                var listCmd = previous as ListCommand<T>;
                if (listCmd == null) throw new Exception("add is command for object List<type>");

                List = listCmd;

                List.Elements = listCmd.Elements;

                T appended = (T)new T().FromArg(args);
                List.Elements.Add(appended);
                List.Appended?.Invoke(appended);
            }
        }

        protected class AtCommand : Command
        {
            public override Command[] Commands => throw new Exception("UNREACHABLE");

            public override string Type => throw new Exception("UNREACHABLE");

            public override string Help => throw new Exception("UNREACHABLE");

            public override string StringRepresentation => throw new Exception("UNREACHABLE");

            public override string CommandText => "at";

            public override Command RefCommandCommand => Element == null ? new NullCommand() : Element;

            public T? Element { get; private set; }

            public AtCommand(){
                Element = null;
            }

            public AtCommand(T element):this()
            {
                Element = element;
            }

            public override void _Execute(ArgumentProvider args, ref object? context, Command previous)
            {
                var listCmd = previous as ListCommand<T>;
                if (listCmd == null) throw new Exception("add is command for object List<type>");

                uint index;
                string arg = args.RequiredNext("at command requires index, index is number > 0");
                if (uint.TryParse(arg, out index) == false)
                    throw new Exception("at command requires index, index is number > 0");

                Element = listCmd.Elements.ElementAtOrDefault((int)index);
            }
        }
    }
}
