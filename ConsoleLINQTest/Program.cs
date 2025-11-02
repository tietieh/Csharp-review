namespace ConsoleLINQTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WhereTest();
            //WhereTest2();
            //OfTypeTest();
            //OrderByTest();
            //MultiOrderByTest();
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
        //Where测试2
        static void WhereTest2()
        {
            //创建学生列表
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };
            //使用委托创建查询条件
            Func<Student, bool> isTeenAger = delegate (Student s)
            {
                return s.Age > 12 && s.Age < 20;
            };
            //使用Where查询
            var filteredResult = from s in studentList
                                 where isTeenAger(s)
                                 select s;
            foreach (var s in filteredResult)
            {
                Console.WriteLine(s.StudentName);
            }
        }
        //OfType测试
        static void OfTypeTest()
        {
            List<object> lists = new List<object>() { 1, "2", 3, "4", 5 };
            //使用OfType查询(查询表达式语法)
            var numbers = from list in lists.OfType<int>()
                          select list;
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
            //使用OfType查询(方法语法)
            lists.OfType<string>().ToList().ForEach(x => Console.WriteLine(x));
        }
        //OrderBy测试
        static void OrderByTest()
        {
            //创建学生列表
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            //使用OrderBy查询(查询表达式语法)
            var orderByResult = from s in studentList
                                orderby s.StudentName
                                select s;
            foreach (var s in orderByResult)
            {
                Console.WriteLine(s.StudentName);
            }
            //按年龄降序
            var orderByDescendingResult = from s in studentList
                                          orderby s.Age descending
                                          select s;
            foreach (var s in orderByDescendingResult)
            {
                Console.WriteLine(s.Age);
            }
            //使用OrderBy查询(方法语法)
            studentList.OrderBy(s => s.StudentName).ToList().ForEach(s => Console.WriteLine(s.StudentName));
            studentList.OrderByDescending(s => s.Age).ToList().ForEach(s => Console.WriteLine(s.Age));
        }
        //多重排序
        static void MultiOrderByTest()
        {
            //创建学生列表
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            //使用OrderBy查询(查询表达式语法)
            var orderByResult = from s in studentList
                                orderby s.StudentName, s.Age
                                select s;
            foreach (var s in orderByResult)
            {
                Console.WriteLine(s.StudentName + " " + s.Age);
            }
            //使用OrderBy查询(方法语法)
            studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age).ToList().ForEach(s => Console.WriteLine(s.StudentName + " " + s.Age));
        }
    }
    //Student类
    internal class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
