using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal abstract class Command
    {
        public abstract Command[] Commands { get; }
        public abstract string Type { get; }
        public abstract string Help { get; }
        public abstract string StringRepresentation { get; }
        public abstract string CommandText { get; }

        public const string HelpCommandText = "help";
        public const string TypeCommandText = "type";
        public const string CommandsCommandText = "commands";

        public virtual Command FromArg(ArgumentProvider args) => throw new Exception($"Cannot create {Type} from string");

        public virtual void _Execute(ArgumentProvider args, Cache cache, Command previous) { }

        public Command Execute(ArgumentProvider args, Cache cache, Command previous)
        {
            string? arg = args.VariadicNext();
            if (arg == null) return this;

            switch (arg)
            {
                case HelpCommandText:
                    return new TextResponseCommand("text", new StringBuilder($"Help:\n{Help}")).Execute(args, cache, this);
                case TypeCommandText:
                    return new TextResponseCommand("text", new StringBuilder($"Type: {Type}")).Execute(args, cache, this);
                case CommandsCommandText:
                    return new TextResponseCommand("text",
                        new StringBuilder("Commands: \nshared: [\n    " + String.Join("\n    ",
                            new string[] {
                                HelpCommandText,
                                TypeCommandText,
                                CommandsCommandText
                            }) + $"\n]\n{Type} :[\n    " + String.Join("\n    ",
                            Commands.Select(cmd => cmd.CommandText)) + "\n]"
                        )
                    ).Execute(args, cache, this);
            }

            _Execute(args, cache, previous);

            foreach (var command in Commands)
                if (command.CommandText == arg)
                    return command.Execute(args, cache, this);

            return new TextResponseCommand("error", new StringBuilder($"command {arg} not found in object \"{Type}\",\nValue:\n{StringRepresentation}"));
        }

        public override string ToString()
        {
            return StringRepresentation;
        }
    }
}
