using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    public class RootCommandToken {
        public string[] Args { get; private set; }
        public RootCommandToken(string[] args)
        {
            Args = args;
        }
    }

    internal class RootCommand : CommandWithType<RootCommandToken>
    {

        public RootCommand(string commandName) :base(commandName)
        {
        }

        public override object ExecuteCommand(RootCommandToken input, CommandManager mgr)
        {
            CommandManager cmdMgr = new CommandManager(new sdecl());
            cmdMgr.Commands.AddRange(mgr.Commands);

            int arg = 0;
            string[] args = input.Args;
            while (arg < args.Length)
            {
                Command curr = cmdMgr.PeekComand(args[arg]);
                cmdMgr.Execute(args[arg++], args.SubArray(arg));
                arg += curr.Signeture.ArgsParsed;
            }

            return cmdMgr.CurrentData;
        }
    }
}
