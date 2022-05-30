

namespace sdecl
{
    class Program
    {
        static void Main(string[] args)
        {
            object? cache = new Cache();
#if DEBUG
                Console.WriteLine(new RootCommand().Execute(new ArgumentProvider(args), ref cache, new NullCommand()));
                Console.WriteLine();
#else
            try
            {
                Console.WriteLine(new RootCommand().Execute(new ArgumentProvider(args), ref cache, new NullCommand()));
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(-1);
            }
#endif
        }
    }
}
