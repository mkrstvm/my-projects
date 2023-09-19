using System;
using SimulatorApp;
using SimulatorApp.Models;
using SimulatorApp.SimulatorFactory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SimulatorAppTest
{
	public class AutoDriverTest
	{
		AutoDriver _driver; 

		[SetUp]
        public void Setup()
        {
			List<ISimulator> _simulators = new List<ISimulator>();
            string[,] field = new string[100, 100];            
         
			_driver = new AutoDriver(_simulators, new string[10, 10]);
            _driver.AddCarToSimulator("A",1,2,"N", "FFRFFFFRRL");
            _driver.AddCarToSimulator("B", 7, 8, "W", "FFLFFFFFFF");

        }

        [TestCase(true, "- A, (1,2) N, FFRFFFFRRL\n- B, (7,8) W, FFLFFFFFFF")]
        [TestCase(false, "- A, collides with B at (5,4) at step 7\n- B, collides with A at (5,4) at step 7")]
        public void RunTest(bool beforeSimulation, string expected)
		{
			_driver.Run();

			var status = _driver.GetStatus(beforeSimulation);
            Assert.That(status, Is.EqualTo(expected));
        }
	}
}

