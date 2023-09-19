using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimulatorApp.Models;
using SimulatorApp.SimulatorFactory;

namespace SimulatorApp.Scheduler
{
    public class SimulatorSchedulerContext
    {
        public IList<ISimulator> Simulators { get; set; }
        public SimulatorSchedulerContext(IList<ISimulator> simulators)
        {
            Simulators = simulators;
        }
        public void Schedule(ScheduleType schedule)
        {
            CreateSchedule(schedule)?.Schedule();
        }

        private IScheduler? CreateSchedule(ScheduleType schedule)
        {
            switch(schedule)
            {
                case ScheduleType.Single:
                    return new SequentialScheduler(Simulators);

                    default:
                        return null;
            }
        }
    }
}