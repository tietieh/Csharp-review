using System;
namespace ConsoleDelegates
{
    internal class Program
    {
        delegate int NumberChanger(int n);
        static void Main(string[] args)
        {
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            nc = nc1;
            nc += nc2;
            nc(2);
            Console.WriteLine(getNum());
            //Func委托
            int a;
            int b;
            Func<int, int, int> add = new Func<int, int, int>(Add);
            Console.WriteLine(add(2, 3));

            Action<string> action = (s) => Console.Write(s);
            action += (s) => Console.Write(" world");
            action("Hello");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Mutiply(int a,int b)
        {
            return a * b;
        }

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
