using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Actions;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    /// <summary>
    ///     Warehouse Simulator
    /// </summary>
    public class WarehouseSimulator
    {
        /// <summary>
        ///     Phisycal Environment
        /// </summary>
        private VirtualEnvironment _environment;
        /// <summary>
        ///     Environment Controllers Simulator
        /// </summary>
        private IList<IControllerEnviromentSimulator> _enviromentSimulators;
        /// <summary>
        ///     Environment Events Timing 
        /// </summary>
        private IList<TemporalData> _timing;
        /// <summary>
        ///     List of All tasks to complete
        /// </summary>
        private IList<TaskToExecute> _tasksToComplete;

        private IList<Helpers> _helpers;

        private DateTime _startDate; 
        private DateTime _finishtDate; 
        private volatile int _currentDate;
        
        public DateTime CuttentDate => _startDate.AddSeconds(_currentDate);

        public WarehouseSimulator()
        {
            
        }

        public void StartSimulator()
        {
            foreach (var helper in _helpers)
            {
                helper.Run();
            }
        }
        public void PauseSimulator()
        {
            
        }
        public void ResumeSimulator()
        {
            
        }
    }
}
