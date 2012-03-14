using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Sumo.Hardware
{
    public enum LineSensorEnum
    {
        Left, Right, Back
    }

    public delegate void LineSensorTriggerdDelegate(LineSensorEnum lineSensor);

    public class LineSensorWrapper
    {
        public event LineSensorTriggerdDelegate LineSensorTriggered;
        
        private struct SensorStruct
        {
            public LineSensor Sensor;
            public LineSensorEnum Position;
        }

        private readonly SensorStruct[] sensors = new SensorStruct[3];
        
        public LineSensorWrapper(Cpu.Pin leftSensorPin, Cpu.Pin rightSensorPin, Cpu.Pin backSensorPin)
        {
            sensors[0] = new SensorStruct() {Position = LineSensorEnum.Left, Sensor= new LineSensor(leftSensorPin)};
            sensors[1] = new SensorStruct() { Position = LineSensorEnum.Right, Sensor = new LineSensor(rightSensorPin) };
            sensors[2] = new SensorStruct() { Position = LineSensorEnum.Back, Sensor = new LineSensor(backSensorPin) };

            new Thread(SensorLoop).Start();
        }

        private void SensorLoop()
        {
            foreach (var sensorStruct in sensors)
            {
                if (sensorStruct.Sensor.GetValue() > 0)
                    this.LineSensorTriggered(sensorStruct.Position);
            }

            Thread.Sleep(50);           
        }
    }
}