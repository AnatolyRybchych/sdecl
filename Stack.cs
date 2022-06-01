using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace sdecl
{
    internal class Stack
    {
        public List<ObservableDirectory> ObservableDirectories { get; set; }
        public List<ObservableFile> ObservableFiles { get; set; }

        public string Name { get; set; }

        public Stack()
        {
            Name = "";
            ObservableDirectories = new List<ObservableDirectory>();
            ObservableFiles = new List<ObservableFile>();
        }

        public Stack(string name) : this()
        {
            Name = name;
        }

        public void Serialize() => File.WriteAllText(GetPath(Name), JsonSerializer.Serialize(this));

        public List<ObservableFile> GetFiles()
        {
            List<ObservableFile> result = new List<ObservableFile>();
            result.AddRange(ObservableFiles);
            foreach (var dir in ObservableDirectories)
                result.AddRange(dir.GetFiles().Select(file => new ObservableFile(file)));
            return result;
        }

        public static Stack Deserialize(string stack)
        {
            Stack? result;
            if (Directory.Exists(StacksFolderPath) == false) Directory.CreateDirectory(StacksFolderPath);

            string stackPath = Path.Combine(StacksFolderPath, stack.Replace(StackExtension, "") + StackExtension);

            if (File.Exists(stackPath))
            {
                try
                {
                    result = JsonSerializer.Deserialize<Stack>(stackPath);
                    if (result == null)
                        File.Delete(stackPath);
                    else
                        return result;
                }
                catch (Exception)
                {
                    File.Delete(stackPath);
                }
                result = new Stack(stack);
                result.Serialize();
                return result;
            }
            else
            {
                result = new Stack(stack);
                result.Serialize();
                return result;
            }
        }

        public static  string GetPath(string name) => Path.Combine(StacksFolderPath, name + StackExtension); 

        public static string StacksFolderPath => Path.Combine(AssemblyPath, StacksFolderName);
        public const string StacksFolderName = "Stacks";
        public const string StackExtension = ".stack.json";

        private static string AssemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location ?? "./sdecl.dll") ?? "./";

        public override string ToString()
        {
            return $"stack \"{Name}\": \n    dirs\n    files\n";
        }
    }
}
