using System;
using Microsoft.SPOT.Hardware;

namespace Sumo.Hardware
{
    public delegate void WhiskerTriggeredDelegate();

    public class Whisker
    {
        public event WhiskerTriggeredDelegate WhiskerTriggered;

        public Whisker(Cpu.Pin digitalPort)
        {
            InterruptPort button = new InterruptPort(digitalPort, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeHigh);
            button.OnInterrupt += ButtonOnOnInterrupt;
        }

        private void ButtonOnOnInterrupt(uint data1, uint data2, DateTime time)
        {
            if (this.WhiskerTriggered != null)
                this.WhiskerTriggered();
        }
    }
}