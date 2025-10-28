namespace ConsoleLINQTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OfTypeTest();

        }
        //Where测试
        static void WhereTest()
        {
            List<int> lists = new List<int>() { 1, 2, 3, 4, 5 };
            //使用LINQ查询（查询表达式语法）
            var numbers = from l in lists
                          where l % 2 == 0
                          select l;
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
            //使用LINQ查询（方法语法）
            lists.Where(x => x % 2 == 0).ToList().ForEach(x => Console.WriteLine(x));
        }
        //OfType测试
        static void OfTypeTest()
        {
            List<object> lists = new List<object>() { 1, "2", 3, "4", 5 };
            //使用OfType查询(查询表达式语法)
            var numbers = lists.OfType<int>();
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
            //使用OfType查询(方法语法)
            lists.OfType<string>().ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
