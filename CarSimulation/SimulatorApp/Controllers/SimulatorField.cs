using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulatorApp
{
    public class SimulatorField
    {
        public SimulatorField(int width, int height)
        {
            this.Width = width;
            Height = height;
            
        }
        public int Width { get; set; }
        public int Height { get; set; }

    }

}