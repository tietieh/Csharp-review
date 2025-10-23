namespace ConsoleSumThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1,2,3,4,5};
            Console.WriteLine($"the sum is: {SumArrayOfThread(array, 2)}");

        }
        //传入数组和起始与结束索引计算和
        static int SumArray(int[] arr, int start, int end)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
        //传入数组和线程数，创建线程，将数组分割成多个部分，每个线程计算和，最后汇总所有线程的结果
        static int SumArrayOfThread(int[] arr, int numOfThread)
        {
            int[] sums = new int[numOfThread];
            int totalSum = 0;
            int baseLength = arr.Length / numOfThread;
            Thread[] threads = new Thread[numOfThread];
            
            //创建线程，将数组分割成多个部分，每个线程计算和
            for (int i = 0; i < numOfThread; i++)
            {
                int threadIndex = i;//线程索引
                int startLength = threadIndex * baseLength;//起始索引
                //结束索引，如果是最后一个线程还要处理余数
                int endLength = startLength + baseLength + (threadIndex == (numOfThread - 1) ? arr.Length % numOfThread : 0);
                //创建线程
                threads[threadIndex] = new Thread(()=> { sums[threadIndex] = SumArray(arr,startLength,endLength); });
                threads[threadIndex].Start();
            }
            //等待所有线程完成
            for (int i = 0; i < numOfThread; i++)
            {
                threads[i].Join();
            }
            //汇总所有线程的结果
            foreach (var s in sums)
            {
                totalSum += s;
            }
            return totalSum;
        }
    }
}
