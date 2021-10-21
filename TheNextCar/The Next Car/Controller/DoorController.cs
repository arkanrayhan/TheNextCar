using System;
using System.Collections.Generic;
using System.Text;
using The_Next_Car.Model;

namespace The_Next_Car.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged onDoorChanged;
        private MainWindow mainWindow;

        public DoorController (OnDoorChanged onDoorChanged)
        {
            this.door = new Door();
            this.onDoorChanged = onDoorChanged;
        }

        public DoorController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void close ()
        {
            this.door.close();
            this.onDoorChanged.doorSecurityChanged("CLOSED", "door is closed");
        }

        public void open()
        {
            this.door.open();
            this.onDoorChanged.doorSecurityChanged("OPENED", "door is opened");
        }

        public void activateLock ()
        {
            if (this.door.isClosed ())
            {
                this.door.activateLock();
                onDoorChanged.doorSecurityChanged("LOCKED", "door is locked");
            } else
            {
                unlock();
            }
        }

        public void unlock ()
        {
            this.door.unlock();
            onDoorChanged.doorSecurityChanged("UNLOCKED", "door is unlocked");
        }

        public bool isClose ()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked ();
        }
    }

    interface OnDoorChanged
    {
        void doorSecurityChanged(string vale, string message);
        void doorStatusChanged(string vale, string message);
    }
}
