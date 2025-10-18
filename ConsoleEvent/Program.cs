namespace ConsoleEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessagePublisher publisher = new MessagePublisher();
            MessageSubscriber subscriber = new MessageSubscriber();
            //订阅事件
            subscriber.SubscribeMessage(publisher);
            //发布消息
            publisher.PublishMessage();
        }
    }

    //发布者类
    public class MessagePublisher
    {
        //定义委托
        public delegate void MessageEventHandler(object sender, EventArgs e);
        //声明事件
        public event MessageEventHandler MessageEvent;
        //触发事件的方法
        protected virtual void OnMessagePublish(EventArgs e)
        {
            MessageEvent?.Invoke(this, e);
        }
        //模拟触发事件的行为
        public void PublishMessage()
        {
            Console.WriteLine("发布了一个消息");
            //实际业务
            Console.WriteLine("------------------");
            //业务完成，触发事件
            OnMessagePublish(EventArgs.Empty);
        }
    }
    //订阅者类
    public class MessageSubscriber
    {
        public void SubscribeMessage(MessagePublisher publisher)
        {
            //订阅事件
            publisher.MessageEvent += MessageReceived;
        }
        //事件处理方法
        private void MessageReceived(object sender, EventArgs e)
        {
            Console.WriteLine("收到了一条消息");
        }
    }
}
