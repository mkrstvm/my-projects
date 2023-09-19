using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.SimulatorFactory;

namespace SimulatorApp.Commands
{
    public class RightCommand : ISimulatorCommand
    {
        public ISimulator Simulator { get; set; }

        public RightCommand(ISimulator simulator)
        {
            Simulator = simulator;
        }
        public void Execute()
        {
            switch (Simulator.Vehicle.CurrentDirection)
            {
                case Models.Direction.N:
                    Simulator.Vehicle.CurrentDirection = Models.Direction.E;
                    break;
                case Models.Direction.S:
                    Simulator.Vehicle.CurrentDirection = Models.Direction.W;
                    break;
                case Models.Direction.E:
                    Simulator.Vehicle.CurrentDirection = Models.Direction.S;
                    break;
                case Models.Direction.W:
                    Simulator.Vehicle.CurrentDirection = Models.Direction.N;
                    break;
                default:
                    break;
            }
        }
    }
}