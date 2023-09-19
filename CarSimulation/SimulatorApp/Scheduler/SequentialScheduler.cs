using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.SimulatorFactory;

namespace SimulatorApp.Scheduler
{
    public class SequentialScheduler : IScheduler
    {
        public IList<ISimulator> Simulators { get; set; }

        public SequentialScheduler(IList<ISimulator> simulators)
        {
            Simulators = simulators;
        }

        public void Schedule()
        {
            List<ISimulator> simulators = Simulators.Where(x => x.CanSimulate()).ToList();

            while (true)
            {
                if (simulators.Count() == 0) return;

                foreach (var simulator in simulators)
                {
                    simulator.SimulateSingle();
                }

                simulators.RemoveAll(x => x.CanSimulate() == false);
            }
        }
    }
}