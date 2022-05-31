﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CacheDirsCommand : CommandWithType<Cache>
    {
        public CacheDirsCommand(string commandName) : base(commandName)
        {

        }

        public override object ExecuteCommand(Cache input, CommandManager mgr)
        {
            return input.Settings.ObservableDirectories;
        }
    }
}
