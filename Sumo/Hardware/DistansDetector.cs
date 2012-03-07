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
            int val = port.Read();
            double voltage = val * 3.3 / 1024;
            Debug.Print(voltage.ToString());
            Debug.Print(((2914 / (val + 5)) - 1).ToString());
            return (2914 / (val + 5)) - 1;
        }


        public int GetValue()
        {
            var value = port.Read();
            Debug.Print(value.ToString());
            return value;
        }
    }
}