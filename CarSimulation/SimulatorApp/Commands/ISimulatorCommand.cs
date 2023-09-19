using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.SimulatorFactory;

namespace SimulatorApp.Commands
{
    public interface ISimulatorCommand
    {
        ISimulator Simulator{get;set;}
        public void Execute();
    }
}