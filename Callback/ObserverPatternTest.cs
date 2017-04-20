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

            bob.setSubject(mp);

            mp.Msg = "Indigo";
            mp.Msg = "Peppermint";

            bill.setSubject(mp);

            mp.Msg = "Napoleon";
            mp.Msg = "Bracelet";

            Console.ReadKey();

        }
    }
}
