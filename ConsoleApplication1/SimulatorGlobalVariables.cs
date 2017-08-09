using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Actions;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    public static class SimulatorGlobalVariables
    {
        //public static IList<SimulatorChange> SimulatorsCurrentTime = new List<SimulatorChange>();
        private static IList<SimulatorTasks> SimulatorsCurrentTasks = new List<SimulatorTasks>();
        private static IList<SimulatorVirtualEnvironment> SimulatorsCurrentEnvironment = new List<SimulatorVirtualEnvironment>();

        //public static DateTime GeCurrentTime(string id)
        //{
        //    return SimulatorsCurrentTime.FirstOrDefault(x => x.ThreadSimulatorID == id).Time;
        //}
        
        public static IList<TaskToExecute> GeCurrentTasks(string id)
        {
            return SimulatorsCurrentTasks.Where(x => x.ThreadSimulatorID == id).Select(x=>x.Task).ToList();
        }
        public static VirtualEnvironment GeCurrentEnvironment(string id)
        {
            return SimulatorsCurrentEnvironment.FirstOrDefault(x => x.ThreadSimulatorID == id).Environment;
        }
    }

    public class SimulatorChange
    {
        public string ThreadSimulatorID { get; set; }
        public DateTime Time { get; set; }
    }

    public class SimulatorTasks
    {
        public string ThreadSimulatorID { get; set; }
        public TaskToExecute Task { get; set; }
    }

    public class SimulatorVirtualEnvironment
    {
        public string ThreadSimulatorID { get; set; }
        public VirtualEnvironment Environment { get; set; }
    }
}
