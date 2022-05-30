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
        public string? Path { get; private set; }
        public bool Reqursive { get; private set; }

        public ObservableDirectory()
        {
            Reqursive = false;
        }

        public ObservableDirectory(string path, bool reqursive)
        {
            Reqursive = reqursive;
            Path = path;
        }

        public static List<ObservableDirectory> ExpandReqursions(ObservableDirectory dir)
        {
            if (dir.IsValid == false) throw new ArgumentException("directory is invalid");

            var list = new List<ObservableDirectory>();
            list.Add(dir);
            if (dir.Reqursive)
                foreach (var childDir in Directory.GetDirectories(dir.Path))
                    list.AddRange(ExpandReqursions(new ObservableDirectory(childDir, true)));
            return list;
        }

        public bool IsValid => Path != null && Directory.Exists(Path);
    }
}
