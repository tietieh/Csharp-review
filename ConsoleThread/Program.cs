namespace ConsoleThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(WriteThreadName);
            Thread thread2 = new Thread(WriteThreadName);

            thread1.Name = "thread one";
            thread2.Name = "thread two";
            Thread.CurrentThread.Name = "main thread";

            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Normal;
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;

            thread1.Start();
            thread2.Start();
            WriteThreadName();
        }
        //锁对象
        static object writeLock = new object();
        static void WriteThreadName()
        {
            lock (writeLock)//加锁保证线程操作不被其他线程打扰
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine($"This thread name is:{Thread.CurrentThread.Name}");
                }
            }
        }
    }
}
