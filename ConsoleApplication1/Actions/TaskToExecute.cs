using ConsoleApplication1.Enum;
using ConsoleApplication1.Model;
using TaskStatus = ConsoleApplication1.Enum.TaskStatus;

namespace ConsoleApplication1.Actions
{
    public class TaskToExecute
    {
        public TaskType Type { get; set; }
        public IActionModel ActionData { get; set; }
        public TaskStatus Status { get; set; }
        public CartesianPointer Position { get; set; }
    }
}
