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

        public virtual Command FromArg(ArgumentProvider args) => throw new Exception($"Cannot create {RefCommandCommand.Type} from string");
        public virtual void _Execute(ArgumentProvider args,ref  object? context, Command previous) { }
        public virtual Command RefCommandCommand => this;

        public Command Execute(ArgumentProvider args, ref object? context, Command previous)
        {
            object? context_cp = context;
            _Execute(args, ref context_cp, previous.RefCommandCommand);

            string? arg = args.VariadicNext();
            if (arg == null) return this.RefCommandCommand;

            
            context_cp = context;
            switch (arg)
            {
                case HelpCommandText:
                    return new TextResponseCommand("text", new StringBuilder($"Help:\n{RefCommandCommand.Help}")).Execute(args, ref context_cp, this).RefCommandCommand;
                case TypeCommandText:
                    return new TextResponseCommand("text", new StringBuilder($"Type: {RefCommandCommand.Type}")).Execute(args, ref context_cp, this).RefCommandCommand;
                case CommandsCommandText:
                    return new TextResponseCommand("text",
                        new StringBuilder("Commands: \nshared: [\n    " + String.Join("\n    ",
                            new string[] {
                                HelpCommandText,
                                TypeCommandText,
                                CommandsCommandText
                            }) + $"\n]\n{RefCommandCommand.Type} :[\n    " + String.Join("\n    ",
                            RefCommandCommand.Commands.Select(cmd => cmd.CommandText)) + "\n]"
                        )
                    ).Execute(args, ref context_cp, this.RefCommandCommand).RefCommandCommand;
            }

            foreach (var command in RefCommandCommand.Commands)
                if (command.CommandText == arg)
                    return command.Execute(args, ref context_cp, this.RefCommandCommand);

            return new TextResponseCommand("error", new StringBuilder($"command {arg} not found in object \"{RefCommandCommand.Type}\",\nValue:\n{RefCommandCommand.StringRepresentation}")).RefCommandCommand;
        }

        public override string ToString() => RefCommandCommand.StringRepresentation;
    }
}
