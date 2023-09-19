using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.Models;

namespace SimulatorApp.SimulatorFactory
{
    public interface ISimulator
    {
        string CommandString { get; set; }
        Vehicle Vehicle { get; set; }
        int Step{get;set;}
        public int Height{get;}
        public int Width{get;}
        public string[,] Field { get; }
        void SimulateSingle();
        bool CanSimulate();
        event SimCollisionEventHandler OnCollided;

        string GetStatus(bool beforeSimulation = true);

    }
}