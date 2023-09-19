using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using SimulatorApp.Models;

namespace SimulatorApp.SimulatorFactory
{
    public class SimulatorFactory
    {
        public ISimulator? Create(VehicleType type, Vehicle vehicle, string commandString, string[,] field)
        {
            switch (type)
            {
                case VehicleType.Car:
                    return new CarSimulator(commandString, vehicle, field);
                default:
                return null;
            }
        }
    }
}