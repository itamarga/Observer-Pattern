using System;

namespace Callback
{
    class ObserverPatternTest
    {
        static void Main(string[] args)
        {
            MessageSubscriber bob = new MessageSubscriber("Bob");
            MessageSubscriber bill = new MessageSubscriber("William");
            MessagePublisher mp = new MessagePublisher();

            // no subscribers
            mp.Msg = "Indigo";

            // one subscriber
            bob.setSubject(mp);
            mp.Msg = "Peppermint";

            // add a second subscriber
            bill.setSubject(mp);
            mp.Msg = "Napoleon";

            // remove the second subscriber
            bill.setSubject(null);
            mp.Msg = "Bracelet";

            Console.ReadKey();

        }
    }
}
