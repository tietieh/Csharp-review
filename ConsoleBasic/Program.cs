namespace ConsoleBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resutl = calculate(0, 100);
            Console.WriteLine(resutl);
        }
        static int calculate(int a, int b)
        {
            int result = 0;
            for (int i = a; i <= b; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                    result += i;
                }
            }
            return result;
        }
    }
}
