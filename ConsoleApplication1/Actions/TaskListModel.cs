using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Actions
{
    public class TaskListModel : IActionModel
    {
        public IList<TaskToExecute> Tasks { get; set; }
    }
}
