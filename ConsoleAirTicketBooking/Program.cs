using System.Collections.Concurrent;
using System.Globalization;

namespace ConsoleAirTicketBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread t = new Thread(IncreasCounter);
            //Thread t1 = new Thread(IncreasCounter);
            //t.Start();
            //t1.Start();
            //t.Join();
            //t1.Join();
            //Console.WriteLine(counter);
            
            //系统提示
            Console.WriteLine("Welcome to Air Ticket Booking System");
            Console.WriteLine("Please select your option:");
            Console.WriteLine("b. Book Ticket");
            Console.WriteLine("c. Cancel Ticket");
            Console.WriteLine("q. Quit");
            //监控线程
            Thread monitorThread = new Thread(MonitorQueue);
            monitorThread.Start();
            //循环判断退出和输入队列
            while (true)
            {
                string? input = Console.ReadLine();
                if (input.ToLower().Equals("q"))
                {
                    Console.WriteLine("Thank you for using our service.");
                    cts.Cancel();//取消监控线程
                    monitorThread.Join();
                    break;
                }
                inputQueue.Enqueue(input);
            }
            monitorThread.Join();//等待监控线程退出
        }
        #region 线程安全的计数器
        //锁对象
        private static readonly object counterLock = new object();
        //计数值
        private static int counter = 0;
        //线程安全的计数器
        static void IncreasCounter()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Increment(ref counter);
                //lock (counterLock)
                //{
                //    counter++;
                //}
            }
        }
        #endregion
        //锁
        private readonly static object sticketsLock = new object();
        //总票数
        private static int totalTickets = 100;
        //余票数
        private static int tickets = 100;
        //队列
        private static ConcurrentQueue<string?> inputQueue = new ConcurrentQueue<string?>();
        //取消令牌
        private static CancellationTokenSource cts = new CancellationTokenSource();
        private static CancellationToken token = cts.Token;
        //监控线程
        static void MonitorQueue()
        {
            while (!token.IsCancellationRequested)
            {
                if (inputQueue.TryDequeue(out string? input) && input != null)
                {
                    //另开线程处理输入，订票和取消订票
                    ThreadPool.QueueUserWorkItem(work => ProcessTicketRequest(input));//使用线程池
                }
                else
                {
                    token.WaitHandle.WaitOne(100);//使用 WaitHandle 等待，可在取消时提前唤醒
                }
            }
        }
        //处理输入
        static void ProcessTicketRequest(string? input)
        {
            if (input.ToLower().Equals("b"))
            {
                TicketBooking();
            }
            else if (input.ToLower().Equals("c"))
            {
                TicketCanceling();
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        //订票
        static void TicketBooking()
        {
            lock (sticketsLock)
            {
                if (tickets > 0)
                {
                    tickets--;
                    Console.WriteLine($"Congratulations! Your ticket has been booked.The tickets remaining are {tickets}.");
                }
                else
                {
                    Console.WriteLine("Sorry, no tickets available.");
                }
            }
        }
        //取消订票
        static void TicketCanceling()
        {
            lock (sticketsLock)
            {
                if (tickets < totalTickets)
                {
                    tickets++;
                    Console.WriteLine($"Your ticket has been cancelled.The tickets remaining are {tickets}.");
                }
                else
                {
                    Console.WriteLine("Sorry, no tickets can be cancelled.");
                }
            }
        }
    }
}
