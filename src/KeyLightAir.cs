using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyLightSwitch
{
    public class Light
    {
        public int on { get; set; }
        public int brightness { get; set; }
        public int temperature { get; set; }
    }

    public class KeyLightAir
    {
        public int numberOfLights { get; set; }
        public List<Light> lights { get; set; }
    }
   
}
