using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.Enum;

namespace ConsoleApplication1.Actions
{
    public class GetTaskStub : IAction<TaskToExecute>
    {
        private IAction<TaskToExecute, TaskListModel> _getNextTask;
        private string _threadSimulatorID;

        public GetTaskStub(string threadSimulatorId, IAction<TaskToExecute, TaskListModel> getNextTask)
        {
            _threadSimulatorID = threadSimulatorId;
            _getNextTask = getNextTask;
        }

        public TaskToExecute Run()
        {
            var tasks = SimulatorGlobalVariables.GeCurrentTasks(_threadSimulatorID);
            var model = new TaskListModel { Tasks = tasks };
            var task = _getNextTask.Run(model);
            return task;
        }
    }
}
