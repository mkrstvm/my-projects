using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.SimulatorFactory;

namespace SimulatorApp.Scheduler
{
    public interface IScheduler
    {
        public IList<ISimulator> Simulators{get;}
        public void Schedule();
    }
}