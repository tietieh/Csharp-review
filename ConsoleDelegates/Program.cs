using System;
namespace ConsoleDelegates
{
    internal class Program
    {
        //定义委托
        delegate int NumberChanger(int n);
        static void Main(string[] args)
        {
            //实例化委托
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            //委托多播
            nc = nc1;
            nc += nc2;
            nc(2);
            Console.WriteLine(getNum());
            //Func委托
            int a = 2;
            int b = 3;
            Func<int, int, int> add = new Func<int, int, int>(Add);
            Console.WriteLine(add(a, b));
            //Action委托
            Action<string> action = (s) => Console.Write(s);
            action += (s) => Console.Write(" world");
            action("Hello");
        }
        //Func委托的实现方法
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Mutiply(int a,int b)
        {
            return a * b;
        }
        //定义nc委托的实现方法
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }
    }
}
