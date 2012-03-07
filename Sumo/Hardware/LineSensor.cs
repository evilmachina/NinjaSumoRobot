using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Sumo.Hardware
{
    // http://bildr.org/2011/06/qre1113-arduino/

    public class LineSensor
    {
        // improve using timer & delegates

        private readonly TristatePort port;

        public LineSensor(Cpu.Pin digitalPin)
        {
            this.port = new TristatePort(digitalPin, true, false, Port.ResistorMode.Disabled);
        }

        public bool GetValue()
        {
            this.port.Active = true; // output
            this.port.Write(true);
            Thread.Sleep(1); // should be 10 micro seconds
            this.port.Active = false;

            var start = Utility.GetMachineTime().Seconds;
            while (this.port.Read() && ((Utility.GetMachineTime().Seconds - start) < 3)) ;
            var diff = Utility.GetMachineTime().Seconds - start;
            return diff >= 3;
        }
    }
}