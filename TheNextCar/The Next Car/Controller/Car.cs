using System;
using System.Collections.Generic;
using System.Text;

namespace The_Next_Car.Controller
{
    class Car
    {
        AccuBatteryController accuBatteryController;
        DoorController doorController;
        OnCarEngineStatusChanged callbackCarEngineStatusChanged;
        private MainWindow mainWindow;

        public Car (AccuBatteryController accuBatteryController, DoorController doorController, OnCarEngineStatusChanged callbackCarEngineStatusChanged)
        {
            this.accuBatteryController = accuBatteryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanged = callbackCarEngineStatusChanged;
        }

        public Car(AccuBatteryController accuBatteryController, DoorController doorController, MainWindow mainWindow)
        {
            this.accuBatteryController = accuBatteryController;
            this.doorController = doorController;
            this.mainWindow = mainWindow;
        }

        public void turnOnPower ()
        {
            this.accuBatteryController.turnOn();
        }

        public void turnOffPower()
        {
            this.accuBatteryController.turnOff();
        }

        public bool powerIsReady ()
        {
            return this.accuBatteryController.accuBatteryIsOn();
        }

        public void closeTheDoor ()
        {
            this.doorController.close();
        }

        public void openTheDoor ()
        {
            this.doorController.open();
        }

        public void lockTheDoor ()
        {
            this.doorController.activateLock();
        }

        public void unlockTheDoor ()
        {
            this.doorController.unlock();
        }

        private bool doorIsClosed ()
        {
            return this.doorController.isClose();
        }

        private bool doorIsLocked ()
        {
            return this.doorController.isLocked();
        }

        public void toggleStartEngineButton ()
        {
            if (!doorIsClosed ())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door is open");
                return;
            }

            if (!doorIsLocked ())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door is unlocked");
                return;
            }

            if (!powerIsReady ())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "no power available");
                return;
            }

            this.callbackCarEngineStatusChanged.carEngineStatusChanged("STARTED", "Engine started");
        }

        public void toggleTheLockDoorButton ()
        {
            if (!doorIsLocked ())
            {
                this.lockTheDoor();
            } else
            {
                this.unlockTheDoor();
            }
        }

        public void toggleTheDoorButton ()
        {
            if (!doorIsClosed ())
            {
                this.closeTheDoor ();
            }
            else
            {
                this.openTheDoor ();
            }
        }

        public void toggleThePowerButton ()
        {
            if (!powerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOffPower();
            }
        }
    }

    interface OnCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string msg);
    }
}
