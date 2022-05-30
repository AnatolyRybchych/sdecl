

namespace sdecl
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(new RootCommand().Execute(new ArgumentProvider(args), new Cache(), new NullCommand()));
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(-1);
            }
        }
    }
}
