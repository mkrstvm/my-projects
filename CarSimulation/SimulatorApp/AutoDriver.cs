using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.SimulatorFactory;
using SimulatorApp.Inputs;
using SimulatorApp.Scheduler;
using SimulatorApp.Models;
using System.Xml.Linq;

namespace SimulatorApp
{
    public delegate void SimCollisionEventHandler(ISimulator simulator);

    public class AutoDriver
    {
        //only for unit test
        public AutoDriver(IList<ISimulator>? simulators, string[,] field): this()
        {
            _simulators = simulators;
            _field = field;            
        }

        public AutoDriver()
        {
            _factory = new SimulatorFactory.SimulatorFactory();
        }

        private IList<ISimulator>? _simulators;
        private string[,] _field;
        SimulatorFactory.SimulatorFactory _factory;

        public void Start()
        {
            try
            {
            mark: _field = InputHandler.GetSimulatorField();
                Console.WriteLine($"You have created a field of {_field.GetLength(0)} x {_field.GetLength(1)}");                
                _simulators = new List<ISimulator>();

                while (true)
                {
                    Console.WriteLine("Please choose from the following options:");
                    Console.WriteLine("[1] Add a car to field");
                    Console.WriteLine("[2] Run simulation");

                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            AddCar();
                            PrintStatus();
                            break;
                        case "2":
                            Run();
                            PrintStatus();
                            PrintStatus(false);                           

                            switch (InputHandler.GetNextStep())
                            {
                                case "1":
                                    goto mark;
                                case "2":
                                    Console.WriteLine("Thank you for running the simulation . Goodbye!");
                                    return;
                                default:
                                    break;
                            }
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while executing....Thank you for running the simulation . Goodbye!");
                return;
            }
        }

        //update other simulators in same location to collided
        private void OnCollision(ISimulator simulator)
        {
            if (simulator.Vehicle.Status != Status.Collided) return;

            var simulators = _simulators.Where(sim => sim.Vehicle.CurrentPosition.Equals(simulator.Vehicle.CurrentPosition)).ToList();
            simulators.ForEach(sim =>
            {
                sim.Vehicle.Status = Status.Collided;
                sim.Step = simulator.Step;
            } ) ;
        }

        public void Run()
        {   
            var context = new SimulatorSchedulerContext(_simulators);
            context.Schedule(Models.ScheduleType.Single);            
        }

        private void PrintStatus(bool beforeSimulation = true)
        {
            if(beforeSimulation )
                Console.WriteLine("Your current list of cars are:");
            else
                Console.WriteLine("After Simulation, the result is:");

            foreach (var sim in _simulators)
                Console.WriteLine(sim.GetStatus(beforeSimulation));
        }

        public string GetStatus(bool beforeSimulation = true)
        {
            List<string> statuses = new List<string>();
            foreach (var sim in _simulators)
            {
                statuses.Add(sim.GetStatus(beforeSimulation));
            }

            return string.Join(Environment.NewLine, statuses);
        }

        private void AddCar()
        {
            InputHandler.GetCar(out string name, out int X, out int Y, out string direction);
            Console.WriteLine($"Please enter the commands for car {name}:");
            string commands = Console.ReadLine();
            AddCarToSimulator(name, X, Y, direction, commands);
        }

        public void AddCarToSimulator(string name, int X, int Y, string direction, string commands)
        {
            var simulator = _factory.Create(VehicleType.Car, new Car(name, new Position(X, Y), Enum.Parse<Direction>(direction)), commands, _field);
            simulator.OnCollided += OnCollision;
            _simulators?.Add(simulator);
        }
    }
}