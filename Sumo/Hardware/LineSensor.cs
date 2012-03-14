using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Sumo.Hardware
{
    // http://bildr.org/2011/06/qre1113-arduino/

    public class LineSensor
    {
        private readonly AnalogInput port;

        public LineSensor(Cpu.Pin analogPin)
        {
            this.port = new AnalogInput(analogPin);
        }

        private int value;
        public int GetValue()
        {
            value = this.port.Read();
            Debug.Print("linesensor value: ");
            Debug.Print(value.ToString());
            return value;
        }
    }
}