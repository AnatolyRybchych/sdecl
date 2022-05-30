﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CommandSignature
    {
        public string CommandName { get; protected set; }
        public List<CommandArgument> Args { get; protected set; }
        public int ArgsParsed { get; private set; }

        public void SendArgs(ArgumentProvider args) 
        {
            ArgsParsed = 0;
            foreach(var arg in Args.Where(arg=>arg.IsRequired))
            {
                arg.Set(args.RequiredNext($"Missing required argument {arg} after {args.CurrentTrace}"));
                ArgsParsed++;
            }

            foreach(var arg in Args.Where(arg => arg.IsRequired == false))
            {
                try
                {
                    string? strArg = args.VariadicNext();
                    if(strArg == null)
                        break;
                    else
                    {
                        arg.Set(strArg);
                        ArgsParsed++;
                    }
                }
                catch(Exception)
                {
                    args.ReturnPrevious();
                }
            }
        }

        public CommandSignature(string commandName)
        {
            ArgsParsed = 0;
            CommandName = commandName;
            Args = new List<CommandArgument>();
        }
    }
}
