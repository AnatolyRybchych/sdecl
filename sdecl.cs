using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace sdecl
{
    internal class Sdecl
    {
        [JsonIgnore]
        public Stack CurrStack { get; set; }
        public string? CurrStackName { get; set; }

        public Sdecl()
        {
            CurrStack = new Stack();
        }

        public void LoadCurrentStack()
        {
            if(CurrStackName == null)
            {
                throw new Exception("Current stack is not defined");
            }
            else
            {
                CurrStack = Stack.Deserialize(CurrStackName);
            }
            Save();
        }

        public static Sdecl Get()
        {
            Sdecl? result;
            if(File.Exists(FilePath))
            {
                try
                {
                    result = JsonSerializer.Deserialize<Sdecl>(File.ReadAllText(FilePath));
                    if (result == null)
                    {
                        File.Delete(FilePath);
                        result = new Sdecl();
                        result.Save();      
                        return result;
                    }
                    else
                        return result;
                }
                catch (Exception)
                {
                    File.Delete(FilePath);
                    result = new Sdecl();
                    result.Save();
                    return result;
                }
            }
            else
            {
                result = new Sdecl();
                result.Save();
                return result;
            }
        }

        public void Save() => File.WriteAllText(FilePath, JsonSerializer.Serialize(this));

        public static readonly string FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location ?? "./sdecl.dll") ?? "./", "sdecl.json");

        public override string ToString()
        {
            return $"use command commands to see avalable commands, example: sdecl commands";
        }
    }
}
