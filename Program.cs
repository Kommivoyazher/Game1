using Game1.program;
public class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine();
            Commands.AnalInput(input);
        }
    }
}
namespace Game1 
{
    public delegate bool CompareOp(object lhs, object rhs);
}