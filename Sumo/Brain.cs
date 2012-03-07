using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Sumo.Hardware;

namespace Sumo
{
    public class Brain
    {
        public void TakeOverTheWord()
        {
            var d = new DistansDetector(Pins.GPIO_PIN_A0);

            Wheels wheels = new Wheels(Pins.GPIO_PIN_D0, Pins.GPIO_PIN_D6, Pins.GPIO_PIN_D1, Pins.GPIO_PIN_D5);
            wheels.Stop();

            Thread.Sleep(2000);

            wheels.Forward();

            Thread.Sleep(2000);

            wheels.Reverse();

            Thread.Sleep(2000);

            wheels.Stop();

            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            bool state = true;
            while (true)
            {
              if(d.GetDistance() < 300)
              {
                  wheels.Reverse();
                  Thread.Sleep(250);
                  wheels.TurnLeft();
                  Thread.Sleep(250);
              }
              else
              {
                  wheels.Forward();
                  Thread.Sleep(100);  
              }
              
              
            }
        }
    }
}
