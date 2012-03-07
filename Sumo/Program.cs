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
            var b = new Brain();
            b.TakeOverTheWord();


            Thread.Sleep(Timeout.Infinite);
        }

    }
}
