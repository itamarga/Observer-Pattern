using System;
using System.Collections.Generic;
using System.Threading;

namespace Callback
{
    class MessagePublisher : Subject
    {
        private List<Observer> observers = new List<Observer>();
        private Mutex observerlsLock = new Mutex();
        private string _msg;
        public string Msg
        {
            get
            {
                return _msg;
            }

            set
            {
                _msg = value;
                lock (observerlsLock)
                {
                    changed = true;
                }
                notifyObservers();
            }
        }
        private bool changed = false;

        [Obsolete("Reimplemented in Msg property setter", true)]
        public void postMessage(string msg)
        {
            this.Msg = msg;
            lock (observerlsLock)
            {
                changed = true;
            }
            notifyObservers();
        }

        public object getUpdate(Observer ob)
        {
            return Msg;
        }

        public void notifyObservers()
        {
            lock (observerlsLock)
            {
                if (changed)
                {
                    foreach (Observer ob in observers)
                    {
                        ob.update();
                    }
                    changed = false;
                }
            }
        }

        public void register(Observer ob)
        {
            lock (observerlsLock)
            {
                observers.Add(ob);
            }
        }

        public void unregister(Observer ob)
        {
            lock (observerlsLock)
            {
                observers.Remove(ob);
            }
        }
    }
}
