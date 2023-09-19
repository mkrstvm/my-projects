using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.Models;

namespace SimulatorApp
{
    public abstract class Vehicle
    {

        protected Vehicle(string name, Position currentPosition, Direction currentDirection)
        {
            Name = name;
            InitialPosition = CurrentPosition = currentPosition;
            Status = Status.Running;
            InitialDirection = CurrentDirection = currentDirection;
        }

        #region properties
        public string Name { get; set; }
        public Position InitialPosition{get;set;}
        public Position CurrentPosition { get;set; }
        public Status Status { get; set; }
        public Direction CurrentDirection { get; set; }
        public Direction InitialDirection { get; set; }
        #endregion

        #region methods

        #endregion
    }
}