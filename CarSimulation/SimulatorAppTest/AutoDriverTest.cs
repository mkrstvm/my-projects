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


        [Test]
		public void RunTest()
		{
			_driver.Run();

			var status = _driver.GetStatus(true);

            Assert.That(status, Is.EqualTo("- A, (1,2) N, FFRFFFFRRL\n- B, (7,8) W, FFLFFFFFFF"));
            status = _driver.GetStatus(false);
            Assert.That(status, Is.EqualTo("- A, collides with B at (5,4) at step 7\n- B, collides with A at (5,4) at step 7"));

        }
	}
}

