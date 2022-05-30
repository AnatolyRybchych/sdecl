using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sdecl
{
    internal abstract class TypedCommandArgument<T> : CommandArgument
    {
        public TypedCommandArgument(bool required, string name) : base(required, name)
        {
        }

        public override Type Type => typeof(T);

        public T? Value => ObjValue == null ? default(T) : (T?)ObjValue;
    }

    internal class StringCommandArgument : TypedCommandArgument<string>
    {
        Regex satisfyingRegex;

        public StringCommandArgument(bool required, string name, string satisfyingRegex = ".*") : base(required, name) => this.satisfyingRegex = new Regex(satisfyingRegex);

        public override object FromString(string arg) => arg;
        protected override bool IsSatisfies(string args) => satisfyingRegex.IsMatch(args);
    }

    internal class PathCommandArgument : TypedCommandArgument<string>
    {
        Regex satisfyingRegex;

        public PathCommandArgument(bool required, string name) : base(required, name)
        {
            if(Environment.OSVersion.Platform == PlatformID.Win32NT)
                this.satisfyingRegex = new Regex(@"^[a-zA-Z]:[\\/][\\/][\\\S|*\S]?.*$");
            else
                this.satisfyingRegex = new Regex(@"[\\/][\\\S|*\S]?.*$");
        }

        public override object FromString(string arg) => arg;
        protected override bool IsSatisfies(string args) => satisfyingRegex.IsMatch(args);
    }

    internal class IntCommandArgument : TypedCommandArgument<int>
    {
        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }

        public IntCommandArgument(bool required, string name, int minValue = int.MinValue, int maxValue = int.MaxValue) : base(required, name)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public override object FromString(string arg) => int.Parse(arg);

        protected override bool IsSatisfies(string args)
        {
            int val;
            return int.TryParse(args, out val) && val >= MinValue && val <= MaxValue;
        }
    }
}
