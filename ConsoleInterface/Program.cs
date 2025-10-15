namespace ConsoleInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.MyMethod();
            MyClassOne myClassOne = new MyClassOne();
            myClassOne.ParentInterfaceMethod();
            myClassOne.MyMethodOne();
        }
    }
    //接口
    interface IMyInterface
    {
        void MyMethod();
    }
    //继承接口的类
    class MyClass : IMyInterface
    {
        public void MyMethod()//实现接口方法
        {
            Console.WriteLine("MyMethod called!");
        }
    }

    //主接口
    interface IParentInterface
    {
        void ParentInterfaceMethod();
    }
    //继承主接口的接口
    interface IMyInterfaceOne : IParentInterface
    {
        void MyMethodOne();
    }
    //实现接口的类
    class MyClassOne : IMyInterfaceOne
    {
        public void ParentInterfaceMethod()
        {
            Console.WriteLine("ParentInterfaceMethod called!");
        }
        public void MyMethodOne()
        {
            Console.WriteLine("MyMethodOne called!");
        }
    }
    
}
