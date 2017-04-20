namespace Callback
{
    class MessageSubscriber : Observer
    {
        private string name;
        private Subject sub;
        private string lastmsg;

        public MessageSubscriber(string name)
        {
            this.name = name;
        }

        public void setSubject(Subject sub)
        {
            this.sub = sub;
            sub.register(this);
        }

        public void update()
        {
            lastmsg = sub.getUpdate(this) as string;
            System.Console.WriteLine(name + " : " + lastmsg);
        }

        ~MessageSubscriber()
        {
            sub.unregister(this);
        }
    }
}
