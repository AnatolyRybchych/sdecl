using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace sdecl
{
    internal class HeaderFile
    {
        public string? Name { get; set; }
        public DateTime? LastChanging { get; set; }

        public static HeaderFile Load(string path) => JsonSerializer.Deserialize<HeaderFile>(path) ?? new HeaderFile();

        public bool IsValid => Name != null && LastChanging != null;
    }
}
