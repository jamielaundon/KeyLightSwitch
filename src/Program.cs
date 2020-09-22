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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace KeyLightSwitch
{
    class Program
    {

        static HttpClient client = new HttpClient();

        static async Task<Uri> SetLightAsync(KeyLightAir light, string path)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                path, light);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        static async Task<KeyLightAir> GetLightAsync(string path)
        {
            KeyLightAir light = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                light = await response.Content.ReadAsAsync<KeyLightAir>();
            }
            return light;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Key Light Switch");
            RunAsync().GetAwaiter().GetResult();

        }

        static async Task RunAsync()
        {
            // TODO read from settings
            client.BaseAddress = new Uri("http://IP-ADDRESS-HERE:9123/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var url = "elgato/lights";
                KeyLightAir keylight = new KeyLightAir();

                // Get the current light status
                keylight = await GetLightAsync(url);

                //Turn off if already on
                if (keylight.lights[0].on == 1)
                {
                    Console.WriteLine("Turning off...");
                    keylight.lights[0].on = 0;
                }
                else
                {
                    // Create a new light
                    // TODO read from settings
                    Console.WriteLine("Turning on...");
                    Light light = new Light
                    {
                        brightness = 20,
                        temperature = 250,
                        on = 1
                    };

                    keylight = new KeyLightAir();
                    keylight.lights = new List<Light>();
                    keylight.lights.Add(light);
                    keylight.numberOfLights = keylight.lights.Count();
                }

                var result = await SetLightAsync(keylight,url);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
