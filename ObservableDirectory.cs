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

        public static List<ObservableDirectory> ExpandReqursions(ObservableDirectory dir)
        {
            if (dir.IsValid == false) throw new ArgumentException("directory is invalid");

            var list = new List<ObservableDirectory>();
            list.Add(dir);
            if (dir.Recursive)
                foreach (var childDir in Directory.GetDirectories(dir.Path))
                    list.AddRange(ExpandReqursions(new ObservableDirectory(childDir, true)));
            return list;
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
                return $"Directory: \"{Path ?? "null"}\" invalid";
            }
        }
    }
}
