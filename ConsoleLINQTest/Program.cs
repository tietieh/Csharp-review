namespace ConsoleLINQTest
{
    internal class Program
    {
        static void Main(string[] args)
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
    }
}
