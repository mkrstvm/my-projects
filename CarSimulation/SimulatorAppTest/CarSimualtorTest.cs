
using SimulatorApp.Commands;
using SimulatorApp.SimulatorFactory;
using Moq;
using SimulatorApp;
using SimulatorApp.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace SimulatorAppTest
{
	public class CarSimualtorTest
	{
        string[,] _field = new string[100, 100];
        Car _car = new Car("A", new SimulatorApp.Models.Position(10, 10), SimulatorApp.Models.Direction.E);

        [SetUp]
        public void Setup()
        {
		}

		[TestCase("F")]
		public void SimulationTest(string command)
		{
			var simualtor = new CarSimulator(command, _car, _field);
            simualtor.SimulateSingle();

            Assert.That(simualtor.Vehicle.Status, Is.EqualTo(Status.Running));
            Assert.That(simualtor.Vehicle.CurrentPosition, Is.EqualTo(new Position(11,10)));
        }

        [TestCase("F")]
        public void SimulationTest_Collosion(string command)
        {
            _field[11, 10] = "B";
            var simualtor = new CarSimulator(command, _car, _field);
            simualtor.SimulateSingle();

            Assert.That(simualtor.Vehicle.Status, Is.EqualTo(Status.Collided));
            Assert.That(simualtor.Vehicle.CurrentPosition, Is.EqualTo(new Position(11, 10)));
            Assert.That(_field[simualtor.Vehicle.CurrentPosition.X, simualtor.Vehicle.CurrentPosition.Y], Is.EqualTo("B,A"));
        }

        [TestCase("FFRFFFFRRL")]
        public void SimulationTest_MultipleCommands(string command)
        {            
            _car.CurrentPosition.X = 1; _car.CurrentPosition.Y = 2; _car.CurrentDirection = Direction.N;
            var simualtor = new CarSimulator(command, _car, _field);
            while(simualtor.CanSimulate())
                simualtor.SimulateSingle();

            Assert.That(simualtor.Vehicle.Status, Is.EqualTo(Status.Running));
            Assert.That(simualtor.Vehicle.CurrentPosition, Is.EqualTo(new Position(5, 4)));
            Assert.That(simualtor.Vehicle.CurrentDirection, Is.EqualTo(Direction.S));
        }
    }
}

