
using SimulatorApp.Commands;
using SimulatorApp.SimulatorFactory;
using Moq;
using SimulatorApp;
using SimulatorApp.Models;

namespace SimulatorAppTest;


public class CommandTests
{
    Mock<ISimulator> _simualtor;
    Car _car = new Car("A", new SimulatorApp.Models.Position(10, 10), SimulatorApp.Models.Direction.E);
    string[,] _field = new string[100, 100];

    [SetUp]
    public void Setup()
    {        

        _simualtor = new Mock<ISimulator>();
        _simualtor.Setup(x => x.Vehicle).Returns(_car);
        _simualtor.Setup(x => x.Width).Returns(100);
        _simualtor.Setup(x => x.Height).Returns(100);
        _simualtor.Setup(x => x.Field).Returns(_field);
    }

    [TestCase(SimulatorApp.Models.Direction.E, SimulatorApp.Models.Direction.S)]
    [TestCase(SimulatorApp.Models.Direction.N, SimulatorApp.Models.Direction.E)]
    [TestCase(SimulatorApp.Models.Direction.W, SimulatorApp.Models.Direction.N)]
    [TestCase(SimulatorApp.Models.Direction.S, SimulatorApp.Models.Direction.W)]
    public void RightCommandTest(SimulatorApp.Models.Direction input, SimulatorApp.Models.Direction output)
    {
        _car.CurrentDirection = input;        
        var rightCommand = new RightCommand(_simualtor.Object);
        rightCommand.Execute();
        Assert.That(_simualtor.Object.Vehicle.CurrentDirection, Is.EqualTo(output));

    }

    [TestCase(SimulatorApp.Models.Direction.E, SimulatorApp.Models.Direction.N)]
    [TestCase(SimulatorApp.Models.Direction.S, SimulatorApp.Models.Direction.E)]
    [TestCase(SimulatorApp.Models.Direction.W, SimulatorApp.Models.Direction.S)]
    [TestCase(SimulatorApp.Models.Direction.N, SimulatorApp.Models.Direction.W)]
    public void LeftCommandTest(SimulatorApp.Models.Direction input, SimulatorApp.Models.Direction output)
    {
        _car.CurrentDirection = input;
        var rightCommand = new LeftCommand(_simualtor.Object);
        rightCommand.Execute();
        Assert.That(_simualtor.Object.Vehicle.CurrentDirection, Is.EqualTo(output));

    }


    [TestCase(SimulatorApp.Models.Direction.N)]
    public void ForwardCommandTest(SimulatorApp.Models.Direction curDir)
    {        
        _car.CurrentDirection = curDir;
        var fwdCommand = new ForwardCommand(_simualtor.Object);
        fwdCommand.Execute();
        Assert.That(_simualtor.Object.Vehicle.CurrentDirection, Is.EqualTo(curDir));
        Assert.That(_simualtor.Object.Vehicle.CurrentPosition, Is.EqualTo(new SimulatorApp.Models.Position(10,11)));
        Assert.That(_simualtor.Object.Vehicle.Status, Is.EqualTo(Status.Running));
        Assert.That(_simualtor.Object.Field[_simualtor.Object.Vehicle.CurrentPosition.X, _simualtor.Object.Vehicle.CurrentPosition.Y], Is.EqualTo("A"));
    }

    [TestCase(SimulatorApp.Models.Direction.N)]
    public void ForwardCommand_NewPosition_collided(SimulatorApp.Models.Direction curDir)
    {
        _field[10, 11] = "B";
        _car.CurrentDirection = curDir;
        var fwdCommand = new ForwardCommand(_simualtor.Object);
        fwdCommand.Execute();
        Assert.That(_simualtor.Object.Vehicle.CurrentDirection, Is.EqualTo(curDir));
        Assert.That(_simualtor.Object.Vehicle.CurrentPosition, Is.EqualTo(new SimulatorApp.Models.Position(10, 11)));
        Assert.That(_simualtor.Object.Vehicle.Status, Is.EqualTo(Status.Collided));
        Assert.That(_simualtor.Object.Field[_simualtor.Object.Vehicle.CurrentPosition.X, _simualtor.Object.Vehicle.CurrentPosition.Y], Is.EqualTo("B,A"));
    }

    [TestCase(SimulatorApp.Models.Direction.N)]
    public void ForwardCommandCollisionTest1(SimulatorApp.Models.Direction curDir)
    {
        _field[10, 11] = "B";
        _car.CurrentDirection = curDir;
        var fwdCommand = new ForwardCommand(_simualtor.Object);
        fwdCommand.Execute();
        Assert.That(_simualtor.Object.Vehicle.CurrentDirection, Is.EqualTo(curDir));
        Assert.That(_simualtor.Object.Vehicle.CurrentPosition, Is.EqualTo(new SimulatorApp.Models.Position(10, 11)));
        Assert.That(_simualtor.Object.Vehicle.Status, Is.EqualTo(Status.Collided));
        Assert.That(_simualtor.Object.Field[_simualtor.Object.Vehicle.CurrentPosition.X, _simualtor.Object.Vehicle.CurrentPosition.Y], Is.EqualTo("B,A"));
    }

}
