namespace RectangleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.Show();
            Console.WriteLine("矩形的面积为{0}", rect.GetArea());
            Console.WriteLine("矩形的周长为{0}", rect.GetPerimeter());
        }
        //矩形类
        public class Rectangle
        {
            private double width = 0;//宽度
            private double height = 0;//高度
            //构造函数
            public Rectangle()
            {
                
            }
            public Rectangle(int width, int height)
            {
                this.width = width;
                this.height = height;
            }
            ~Rectangle()
            {
                Console.WriteLine("析构函数");
            }
            //获取面积
            public double GetArea()
            {
                return width * height;
            }
            //获取周长
            public double GetPerimeter()
            {
                return 2 * (width + height);
            }
            //展示
            public void Show()
            {
                if (width == 0 || height == 0)
                {
                    Console.WriteLine("矩形尚未初始化");
                    return;
                }
                Console.WriteLine("矩形的宽度为{0}，高度为{1}", width, height);
            }
        }
    }
}
