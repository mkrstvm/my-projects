using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulatorApp.Models
{
    public class Position
    {
        public int X;
        public int Y;

        public Position(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Position == false) return false;

            Position pos = obj as Position;

            return this.X == pos.X && this.Y == pos.Y;
        }
    }
}