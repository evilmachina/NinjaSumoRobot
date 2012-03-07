using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Sumo.Hardware;

namespace Sumo
{
    public class Program
    {                
        public static void Main()
        {
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
                led.Write(state);
                Thread.Sleep(250);
                state = !state;
            }
        }

    }
}
