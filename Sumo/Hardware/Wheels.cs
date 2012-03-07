using System;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Sumo.Hardware
{
    public class Wheels
    {

        private readonly OutputPort motorOneDirection;
        private readonly OutputPort motorTwoDirection;
        private readonly PWM motorOneSpeed;
        private readonly PWM motorTwoSpeed;

        public Wheels(Cpu.Pin motorOneDirectionPin, Cpu.Pin motorOneSpeedPin,
                      Cpu.Pin motorTwoDirectionPin, Cpu.Pin motorTwoSpeedPin)
        {
            this.motorOneDirection = new OutputPort(motorOneDirectionPin, false);
            this.motorTwoDirection = new OutputPort(motorTwoDirectionPin, false);

            this.motorOneSpeed = new PWM(motorOneSpeedPin);
            this.motorTwoSpeed = new PWM(motorTwoSpeedPin);
        }

        public void Forward()
        {
            this.motorOneDirection.Write(true);
            this.motorTwoDirection.Write(true);
            
            this.motorOneSpeed.SetPulse(10000, 10000);
            this.motorTwoSpeed.SetPulse(10000, 10000);

            
        }

        public void Reverse()
        {
            this.motorOneDirection.Write(false);
            this.motorTwoDirection.Write(false);

            this.motorOneSpeed.SetPulse(10000, 10000);
            this.motorTwoSpeed.SetPulse(10000, 10000);
        }

        public void TurnLeft()
        {
            throw new NotImplementedException();
        }

        public void TurnRight()
        {
            throw new NotImplementedException();
        }

        public void SpinLeft()
        {
            throw new NotImplementedException();
        }

        public void SpinRight()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            this.motorOneDirection.Write(false);
            this.motorTwoDirection.Write(false);

            this.motorOneSpeed.SetPulse(10000,0);
            this.motorTwoSpeed.SetPulse(10000, 0);
        }
    }
}