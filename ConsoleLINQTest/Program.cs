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
            //GroupByTest();
            //ToLookUpTest();
            //JoinTest();
            //JoinTest2();
            //GroupJoinTest();
            //SelectTest();
            //SelectManyTest();
            //LimitTest();
            //ContainsTest();
            Aggregate();
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
        //GroupBy测试
        static void GroupByTest()
        {
            //创建学生列表
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            //使用GroupBy查询(查询表达式语法)
            var groupByResult = from s in studentList
                                group s by s.Age;
            foreach (var g in groupByResult)
            {
                Console.WriteLine("Age: " + g.Key);
                foreach (var s in g)
                {
                    Console.WriteLine("Name: " + s.StudentName);
                }
            }
            //使用GroupBy查询(方法语法)
            var groupByResult2 = studentList.GroupBy(s => s.Age);
            foreach (var g in groupByResult2)
            {
                Console.WriteLine("Age: " + g.Key);
                foreach (var s in g)
                {
                    Console.WriteLine("Name: " + s.StudentName);
                }
            }
        }
        //ToLookUp测试
        static void ToLookUpTest()
        {
            //创建学生列表
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            //使用ToLookUp查询(方法语句)
            var lookUpResult = studentList.ToLookup(s => s.Age);
            foreach (var g in lookUpResult)
            {
                Console.WriteLine("Age: " + g.Key);
                foreach (var s in g)
                {
                    Console.WriteLine("Name: " + s.StudentName);
                }
            }
        }
        //Join测试
        static void JoinTest()
        {
            IList<string> strList1 = new List<string>()
            {
                "One",
                "Two",
                "Three",
                "Four"
            };

            IList<string> strList2 = new List<string>()
            {
                "One",
                "Two1",
                "Three1",
                "Four1"
            };

            var innerJoin = strList1.Join(strList2,
                                  str1 => str1,
                                  str2 => str2,
                                  (str1, str2) => str1);
            foreach (var item in innerJoin)
            {
                Console.WriteLine(item);
            }
        }
        //Join测试2
        static void JoinTest2()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            List<Standard> standardList = new List<Standard>()
            {
                new Standard() { StandardID = 1, StandardName = "Mathematics" },
                new Standard() { StandardID = 2, StandardName = "Science" },
                new Standard() { StandardID = 3, StandardName = "English" },
                new Standard() { StandardID = 4, StandardName = "Social Studies" }
            };

            var joinResult = studentList.Join(standardList,
                                s1 => s1.StudentID,
                                s2 => s2.StandardID,
                                (s1, s2) => new { StudentName = s1.StudentName, StandardName = s2.StandardName });
            foreach (var item in joinResult)
            {
                Console.WriteLine(item.StudentName + " " + item.StandardName);
            }
        }
        //GroupJoin测试
        static void GroupJoinTest()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            List<Standard> standardList = new List<Standard>()
            {
                new Standard() { StandardID = 1, StandardName = "Mathematics" },
                new Standard() { StandardID = 2, StandardName = "Science" },
                new Standard() { StandardID = 3, StandardName = "English" },
                new Standard() { StandardID = 4, StandardName = "Social Studies" }
            };

            var groupJoinResult = standardList.GroupJoin(studentList,
                                s1 => s1.StandardID,
                                s2 => s2.StudentID,
                                (s1, s2) => new { StandardName = s1.StandardName, Students = s2 });
            foreach (var item in groupJoinResult)
            {
                Console.WriteLine(item.StandardName);
                foreach (var standard in item.Students)
                {
                    Console.WriteLine(standard.StudentName);
                }
            }
        }
        //Select测试
        static void SelectTest()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            //使用Select查询(查询表达式语法)
            var result = from num in numbers
                         select num * 2;
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }
            //使用Select查询(方法语法)
            var result1 = numbers.Select(x => x * 2);
            foreach (var num in result1)
            {
                Console.WriteLine(num);
            }
        }
        //SelectMany测试
        static void SelectManyTest()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> numbers2 = new List<int>() { 10, 20, 30, 40, 50 };
            //使用SelectMany查询(查询表达式语法)
            var result = from num in numbers
                         from num2 in numbers2
                         select num * num2;
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }
            //使用SelectMany查询(方法语法)
            var result1 = numbers.SelectMany(x => numbers2, (x, y) => x * y);
            foreach (var num in result1)
            {
                Console.WriteLine(num);
            }
        }
        //限定运算符测试
        static void LimitTest()
        {
            Student[] students = new Student[]
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            //All
            Console.WriteLine(students.All(s => s.Age >= 18));
            //Any
            Console.WriteLine(students.Any(s => s.Age >= 20));
        }
        //Contains
        static void ContainsTest()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.Contains(3));

            //对引用类型判断
            List<Student> students = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            Student stu = new Student() { StudentID = 1, StudentName = "John", Age = 18 };

            Console.WriteLine(students.Contains(stu, new StudentComparer()));
        }
        //Aggregate测试
        static void Aggregate()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            //使用Aggregate查询
            var result = numbers.Aggregate((x, y) => x + y);
            Console.WriteLine(result);
            List<string> numbers2 = new List<string>() { "1", "2", "3", "4", "5" };
            var result2 = numbers2.Aggregate((x, y) => x +"," + y);
            Console.WriteLine(result2);
            //学生集合
            IList<Student> students = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            //使用Aggregate查询
            var result3 = students.Aggregate<Student,string>(
                 "StudentName: ",
                 (str, student) => str += student.StudentName + ", ");
            Console.WriteLine(result3);
            var result4 = students.Aggregate<Student, string,string>(
                 "StudentName: ",
                 (str, student) => str += student.StudentName + ", ",
                 str => str.TrimEnd(',',' '));
            Console.WriteLine(result4);
        }
    }
    //需要一个继承IEqualityComparer接口的类，重写Equals方法和GetHashCode方法
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.Age == y.Age && x.StudentName == y.StudentName)
            {
                return true;
            }
            return false;
        }
        public int GetHashCode(Student obj)
        {
            return obj.Age.GetHashCode() ^ obj.StudentName.GetHashCode();
        }
    }
    //Student类
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
}
