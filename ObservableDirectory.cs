using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class ObservableDirectory
    {
        public string? Path { get; set; }
        public bool Recursive { get; set; }

        public ObservableDirectory()
        {
            Recursive = false;
        }

        public ObservableDirectory(string path, bool reqursive)
        {
            Recursive = reqursive;
            Path = path;
        }

        public string[] GetFiles()
        {
            if (IsValid)
            {
                List<string> result = new List<string>();

                result.AddRange(Directory.GetFiles(Path));
                foreach (var dir in Directory.GetDirectories(Path))
                    result.AddRange(new ObservableDirectory(dir, true).GetFiles());
                
                return result.ToArray();
            }
            else
            {
                return new string[0];
            }
        }

        public bool IsValid => Path != null && Directory.Exists(Path);

        public override string ToString()
        {
            if (IsValid)
            {
                return $"Directory: \"{Path}\" {(Recursive ? "recursive" : "")}";
            }
            else
            {
                return $"Directory: \"{Path ?? "null"}\" {(Recursive ? "recursive" : "")} invalid";
            }
        }
    }
}
