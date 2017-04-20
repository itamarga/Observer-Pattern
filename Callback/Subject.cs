using System;

namespace Callback
{
    interface Subject
    {
        void register(Observer ob);
        void unregister(Observer ob);
        void notifyObservers();
        Object getUpdate(Observer ob);
    }
}
