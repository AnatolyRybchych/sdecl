using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class StackFindCommand : CommandWithTypeOrDerivative<IEnumerable<ObservableFile>>
    {
        public StringCommandArgument Target { get; private set; }
        public IntCommandArgument LinesBefore { get; private set; }
        public IntCommandArgument LinesAfter { get; private set; }
        public IntCommandArgument MaxMatches { get; private set; }


        public StackFindCommand(string commandName) : base(commandName)
        {
            Target = new StringCommandArgument(true, "target", ".+");
            LinesBefore = new IntCommandArgument(false, "lines before", 0);
            LinesAfter = new IntCommandArgument(false, "lines after", 0);
            MaxMatches = new IntCommandArgument(false, "max matches count", 1);

            Signeture.Args.Add(Target);
            Signeture.Args.Add(LinesBefore);
            Signeture.Args.Add(LinesAfter);
            Signeture.Args.Add(MaxMatches);
        }

        public override string Help => "searching text in current stack files";

        public override object ExecuteCommand(IEnumerable<ObservableFile> input, CommandManager.CommandManager mgr)
        {
            List<string> results = new List<string>();
            int matches = 0;
            int maxMatches = MaxMatches.ObjValue == null ? int.MaxValue : MaxMatches.Value;
            string toFind = Target.Value;
            foreach (var file in input)
            {
                string text = File.ReadAllText(file.Path);

                int index = -1;
                int newIndex;
                while ((newIndex = text.IndexOf(toFind, ++index))!= -1)
                {
                    results.Add(GetLines(text, newIndex, LinesBefore.Value, LinesAfter.Value));
                    index = newIndex;
                }
            }

            return results;
        }


        public static string GetLines(string str, int index, int linesBefore, int linesAfter)
        {
            int start = index;
            int end = index;

            int lineLen = str.Length;
            int lineLast = lineLen - 1;
            while (start > 0)
            {
                if(str[--start] == '\n')
                {
                    start += 3;
                    break;
                }
            }
            while (end < lineLast)
                if (str[++end] == '\n')
                    break;

            while (linesBefore != 0 && start != 1)
            {
                if (str[--start] == '\n') linesBefore--;
            }
            if (start > 2) start -= 2;
            else if (start > 0) start = 0;

            while (linesAfter != 0 && end != lineLast)
            {
                if (str[++end] == '\n') linesAfter--;
            }

            return str.Substring(start, end - start);
        }
    }
}
