namespace ConsoleBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //调用Calculate方法
            int resutl = Calculate(0, 100);
            Console.WriteLine(resutl);
            //调用BitCalculate方法
            BitCalculate(1, 2);
            //条件运算符表达式
            int a = 3,b = 5, c = 7;
            if ( a < b && b < c || a > c)
            {
                Console.WriteLine("true");
            }
            //移位运算
            int[] arr = {1, 2, 3, 4, 5 };
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] <<= 2; //左移两位
                Console.WriteLine(arr[i]);
            }

             
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
