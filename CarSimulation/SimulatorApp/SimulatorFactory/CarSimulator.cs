using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimulatorApp.Commands;
using SimulatorApp.Models;

namespace SimulatorApp.SimulatorFactory
{
    public delegate void CollisionEventHandler();

    public class CarSimulator : ISimulator
    {
        public string CommandString { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Step { get; set; }

        public string[,] Field{get;set;}
        public Action<ISimulator> OnCollision { get; set; }
        public int Height{get;set;}
        public int Width{get;set;}
        public event SimCollisionEventHandler OnCollided;

        private string collidedCars;

        private Queue<ISimulatorCommand>? CommandsQ;

        

        public CarSimulator(string commandString, Vehicle vehicle, string[,] field)
        {
            Field = field;            
            Height = Field.GetLength(0);
            Width = Field.GetLength(1);
            CommandString = commandString;
            Vehicle = vehicle;
            InitializeCommandsQ();
        }

        private void InitializeCommandsQ()
        {
            CommandsQ = new Queue<ISimulatorCommand>();
            foreach (char ch in CommandString.ToCharArray())
            {
                switch (ch)
                {
                    case 'L':
                        CommandsQ.Enqueue(new LeftCommand(this));
                        break;
                    case 'R':
                        CommandsQ.Enqueue(new RightCommand(this));
                        break;
                    case 'F':
                        var fwdCmd = new ForwardCommand(this);
                        fwdCmd.OnCollided += FwdCmd_OnCollided;
                        CommandsQ.Enqueue(fwdCmd);
                        break;
                }

            }
        }

        private void FwdCmd_OnCollided()
        {
            if (OnCollided != null) OnCollided(this);
        }
        
        private void ExecuteTopCommand()
        {
            if (CommandsQ == null || CommandsQ.Count == 0) return;
            Step++;
            CommandsQ.Dequeue().Execute();
            
        }
       
        public void SimulateSingle()
        {
            ExecuteTopCommand();
        }

        public string GetStatus(bool beforeSimulation = true)
        {
            if(beforeSimulation )
                return  $"- {Vehicle.Name}, ({Vehicle.InitialPosition.X},{Vehicle.InitialPosition.Y}) {Vehicle.InitialDirection}, {CommandString}";
            if(Vehicle.Status == Status.Running)
                return $"- {Vehicle.Name}, (,{Vehicle.CurrentPosition.X},{Vehicle.CurrentPosition.Y}) {Vehicle.CurrentDirection}";
            else
                {
                    var collidedcars = Field[Vehicle.CurrentPosition.X, Vehicle.CurrentPosition.Y].Split(",").Where(x => !x.Equals(Vehicle.Name));
                    return $"- {Vehicle.Name}, collides with {String.Join(",", collidedcars)} at ({Vehicle.CurrentPosition.X},{Vehicle.CurrentPosition.Y}) at step {Step}";
                }
            
        }

        public bool CanSimulate()
        {
            return Vehicle.Status ==  Status.Running && CommandsQ != null && CommandsQ.Count != 0;
        }
    }
}