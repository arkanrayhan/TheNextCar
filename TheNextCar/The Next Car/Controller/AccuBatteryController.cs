using System;
using System.Collections.Generic;
using System.Text;
using The_Next_Car.Model;

namespace The_Next_Car.Controller
{
    class AccuBatteryController
    {
        private AccuBattery accuBattery;
        private OnPowerChanged callBackOnPowerChanged;
        private MainWindow mainWindow;

        public AccuBatteryController (OnPowerChanged callBackOnPowerChanged)
        {
            this.accuBattery = new AccuBattery(12);
            this.callBackOnPowerChanged = callBackOnPowerChanged;
        }

        public AccuBatteryController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public bool accuBatteryIsOn ()
        {
            return this.accuBattery.isOn();
        }

        public void turnOn ()
        {
            this.accuBattery.turnOn();
            this.callBackOnPowerChanged.onPowerChangedStatus("ON", "power is on");
        }
        public void turnOff()
        {
            this.accuBattery.turnOff();
            this.callBackOnPowerChanged.onPowerChangedStatus("OFF", "power is off");
        }

    }

    interface OnPowerChanged 
    {
        void onPowerChangedStatus(string value, string message);
    }
}
