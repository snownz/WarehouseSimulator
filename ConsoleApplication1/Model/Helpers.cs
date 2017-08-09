using System.Threading;
using ConsoleApplication1.Actions;
using ConsoleApplication1.Enum;

namespace ConsoleApplication1.Model
{
    public class Helpers : Npc
    {
        private TaskToExecute _task;
        private volatile int _totalTime;
        
        private readonly IAction<TaskToExecute> _getTask;
        private readonly IAction<int, IActionModel> _buildPallet;
        private readonly IAction<int, IActionModel> _refuelLocation;
        private readonly IAction<int, IActionModel> _movePallet;
        private readonly IAction<int, IActionModel> _cleanLocation;

        private double _buildPalletScore;
        private double _refuelLocationScore;
        private double _movePalletScore;
        private double _cleanLocationScore;

        public int TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
        }
        public string Name { get; set; }

        public Helpers(IAction<TaskToExecute> getTask, IAction<int, IActionModel> buildPallet,
            IAction<int, IActionModel> refuelLocation, IAction<int, IActionModel> movePallet,
            IAction<int, IActionModel> cleanLocation, IAction<int, ActionModelMoveToLocation> move): base(move) 
        {
            _getTask = getTask;
            _buildPallet = buildPallet;
            _refuelLocation = refuelLocation;
            _movePallet = movePallet;
            _cleanLocation = cleanLocation;
            base._taskRunner = new Thread(ExecuteActions);
        }

        private int ExecuteTask()
        {
            switch (_task.Type)
            {
                case TaskType.BuildPallet:
                    return _buildPallet.Run(_task.ActionData, this, _buildPalletScore);
                case TaskType.RefuelLocation:
                    return _refuelLocation.Run(_task.ActionData, this, _refuelLocationScore);
                case TaskType.MovePallet:
                    return _movePallet.Run(_task.ActionData, this, _movePalletScore);
                case TaskType.CleanLocation:
                    return _cleanLocation.Run(_task.ActionData, this, _cleanLocationScore);
                default:
                    return 0;
            }
        }
        private void ExecuteActions()
        {
            do
            {
                // Get Task
                _task = _getTask.Run();
                if(_task == null) continue;

                // Move to Task
                var time = Move.Run(new ActionModelMoveToLocation() { CurrentLocation = Position, To = _task.Position, AvarageSpeed = _ms });

                // Execute Task
                time += _task == null ? 0 : ExecuteTask();
                _totalTime += time;
            } while (true);
        }
    }
}
