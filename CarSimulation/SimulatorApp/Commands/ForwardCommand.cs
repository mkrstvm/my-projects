using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulatorApp.Models;
using SimulatorApp.SimulatorFactory;

namespace SimulatorApp.Commands
{    
    public class ForwardCommand : ISimulatorCommand
    {
        public ISimulator Simulator { get; set; }
        
        public event CollisionEventHandler OnCollided;

        public ForwardCommand(ISimulator simulator)
        {
            Simulator = simulator;
        }
        public void Execute()
        {
            if (Simulator.Vehicle.Status == Status.Collided)
                return;

            Position newPos = new Position(Simulator.Vehicle.CurrentPosition);
            switch (Simulator.Vehicle.CurrentDirection)
            {
                case Models.Direction.N:
                    newPos.Y +=1;
                    break;
                case Models.Direction.S:
                    newPos.Y -= 1;
                    break;
                case Models.Direction.E:
                    newPos.X += 1;
                    break;
                case Models.Direction.W:
                    newPos.X -= 1;
                    break;
                default:
                    break;
            }
            this.UpdatePosition(newPos);
        }

        private void UpdatePosition(Position newPosition)
        {                
            //vehicle at boarder
            if (newPosition.X < 0 || newPosition.X >= Simulator.Width || newPosition.Y < 0 || newPosition.Y >= Simulator.Height)
            {
                return;
            }
              
            if (String.IsNullOrEmpty(Simulator.Field[newPosition.X,newPosition.Y]) == false) //collision scenario
            {
                //collidedCars = Simulator.Field[newPosition.X][newPosition.Y];
                StringBuilder str = new StringBuilder();
                str.Append(Simulator.Field[newPosition.X,newPosition.Y]);
                str.Append($",{Simulator.Vehicle.Name}");
                Simulator.Vehicle.Status = Status.Collided;
                Simulator.Field[newPosition.X,newPosition.Y] = str.ToString();                
            }
            else
            {                
                Simulator.Field[newPosition.X,newPosition.Y] = Simulator.Vehicle.Name;
            }
            Simulator.Field[Simulator.Vehicle.CurrentPosition.X, Simulator.Vehicle.CurrentPosition.Y] = "";
            Simulator.Vehicle.CurrentPosition = newPosition;

            if (Simulator.Vehicle.Status == Status.Collided && OnCollided != null) OnCollided();
        }
    }
}