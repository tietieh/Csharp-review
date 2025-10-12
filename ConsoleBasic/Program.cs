namespace ConsoleBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int resutl = Calculate(0, 100);
            //Console.WriteLine(resutl);
            BitCalculate(1, 2);
        }
        //接受两个整数参数a和b，计算从a到b之间所有能被3整除的数的和
        static int Calculate(int a, int b)
        {
            int result = 0;
            for (int i = a; i <= b; i++)
            {
                if (i % 3 == 0)
                {
                    result += i;
                }
            }
            return result;
        }
        //位运算
        static void BitCalculate(int a, int b)
        {
            Console.WriteLine(a & b); //按位与
            Console.WriteLine(a | b); //按位或
            Console.WriteLine(a ^ b); //按位异或
        }
    }
}
