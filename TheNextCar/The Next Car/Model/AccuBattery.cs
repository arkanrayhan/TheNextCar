using System;
using System.Collections.Generic;
using System.Text;

namespace The_Next_Car.Model
{
    class AccuBattery
    {
        private int voltage;
        private Boolean stateOn = false;

        public AccuBattery (int voltage)
        {
            this.voltage = voltage;
        }

        public void turnOn ()
        {
            this.stateOn = true;
        }

        public void turnOff ()
        {
            this.stateOn = false;
        }

        public Boolean isOn ()
        {
            return this.stateOn;
        }
    }
}
