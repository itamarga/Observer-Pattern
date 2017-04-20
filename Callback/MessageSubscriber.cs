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
            if (null != this.sub)
            {
                this.sub.unregister(this);
            }

            this.sub = sub;

            if (null != this.sub)
            {
                sub.register(this);
            }
        }

        public void update()
        {
            lastmsg = sub.getUpdate(this) as string;
            System.Console.WriteLine(name + " : " + lastmsg);
        }

        ~MessageSubscriber()
        {
            if (null != sub)
            {
                sub.unregister(this);
            }
        }
    }
}
