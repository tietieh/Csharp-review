using static ConsoleDelegates2.Program;

namespace ConsoleDelegates2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintString ps1 = WriteToScreen;
            PrintString ps2 = WriteToFile;
            sendString(ps1, "Hello World!");
            sendString(ps2, "This is a test string.");
        }
        //文件流
        static FileStream fs;
        static StreamWriter sw;
        //委托定义
        public delegate void PrintString(string message);
        //打印到屏幕
        static void WriteToScreen(string message)
        {
            Console.WriteLine("The String is: {0}",message);
        }
        //打印到文件
        static void WriteToFile(string message)
        {
            if (fs == null)
            {
                fs = new FileStream("D:\\Desktop\\Test.txt", FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(message);
                sw.Close();
                fs.Close();
            }
            else
            {
                sw.WriteLine(message);
                sw.Close();
                fs.Close();
            }
        }
        // 该方法把委托作为参数，并使用它调用方法
        public static void sendString(PrintString ps, string message)
        {
            ps(message);
        }
    }
}
