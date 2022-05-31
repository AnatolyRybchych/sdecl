using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sdecl.CommandArgs
{
    internal class PathCommandArgument : TypedCommandArgument<string>
    {
        Regex satisfyingRegex;

        public PathCommandArgument(bool required, string name) : base(required, name)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                this.satisfyingRegex = new Regex(@".*");
            else
                this.satisfyingRegex = new Regex(@".*");
        }

        public override object FromString(string arg) => arg;
        protected override bool IsSatisfies(string args) => satisfyingRegex.IsMatch(args);
    }
}
