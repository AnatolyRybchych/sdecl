

namespace sdecl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new RootCommand().Execute(new ArgumentProvider(args), new Cache(), new NullCommand())); ;
        }
    }
}
