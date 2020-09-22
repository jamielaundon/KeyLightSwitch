// KeyLightSwitch by Jamie Laundon
// Simple Elgato Key Light Air Light Switch App
// https://github.com/jamielaundon/KeyLightSwitch
// Elgato Key Light Airs are great, but hard to control if you have multiple VLANs that don't support mDNS
//
// Controls Elgato Key Light Air API at http://ip.of.light:9123/elgato/lights 
// JSON looks like: {"numberOfLights":1,"lights":[{"on":1,"brightness":5,"temperature":251}]}
// Reads preferred brightness/temperature settings from settings file
// Running app GETs the current state, and toggles to preferred brightness and temp, or off. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KeyLightSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KeyLightSwitch");

        }
    }
}
