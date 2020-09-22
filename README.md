# KeyLightSwitch
## Simple .NET App to turn on Elgato Key Light Air

Elgato Key Light Airs are great, but hard to control if you have multiple VLANs that don't support mDNS

 - Controls Elgato Key Light Air API at http://ip.of.light:9123/elgato/lights 
 - JSON looks like: {"numberOfLights":1,"lights":[{"on":1,"brightness":5,"temperature":251}]}
 - Reads preferred brightness/temperature settings from settings file
 - Running app GETs the current state, and toggles to preferred brightness and temp, or off. 
