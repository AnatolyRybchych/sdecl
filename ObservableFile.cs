using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class ObservableFile
    {
        public string? Path { get; set; }
        public bool IsValid => Path != null && File.Exists(Path);

        public ObservableFile()
        {

        }


        public ObservableFile(string path)
        {
            Path = path;
        }

        public override string ToString()
        {
            if (IsValid)
            {
                return $"File: {Path}";
            }
            else
            {
                return $"File: \"{Path ?? "null"}\" invalid";
            }
        }
    }
}
