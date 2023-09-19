using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.Models;

namespace SimulatorApp
{
    public class Car : Vehicle
    {
        public Car(string name, Position currentPosition, Direction currentDirection) : base(name,currentPosition, currentDirection)
        {
            
        }    
    }
}