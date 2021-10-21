using System;
using System.Collections.Generic;
using System.Text;

namespace The_Next_Car.Model
{
    class Door
    {
        public bool closed;
        public bool locked;

        public void close ()
        {
            this.closed = true;
        }

        public void open ()
        {
            this.closed = false;
        }

        public void activateLock ()
        {
            this.locked = true;
        }

        public void unlock()
        {
            this.locked = false;
        }

        public bool isLocked ()
        {
            return this.locked;
        }

        public bool isClosed ()
        {
            return this.closed;
        }
    }
}
