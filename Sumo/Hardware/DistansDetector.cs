using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Sumo.Hardware
{
    public class DistansDetector
    {
        private const float Y0 = 3;
        private const float X0 = 315;
        private const float Y1 = 30;
        private const float X1 = 30;
        private const float C = (Y1 - Y0) / (1 / X1 - 1 / X0);
        private readonly AnalogInput port;

        public DistansDetector(Cpu.Pin analogPin)
        {
            this.port = new AnalogInput(analogPin);
            this.port.SetRange(0, 100);
        }

        public float GetDistance()
        {
            var value = port.Read();
            Debug.Print(value.ToString());
            return C / (value + (float).001) - (C / X0) + Y0;
        }


        public int GetValue()
        {
            var value = port.Read();
            Debug.Print(value.ToString());
            return value;
        }
    }
}