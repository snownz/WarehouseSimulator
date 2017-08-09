using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Actions
{
    public class MovePersonStub : IAction<int, MoveTo>
    {
        private readonly IAction<int, MoveTo> _calculateRoute;

        public MovePersonStub(IAction<int, MoveTo> calculateRoute)
        {
            _calculateRoute = calculateRoute;
        }

        public int Run(MoveTo model)
        {
            var dist = _calculateRoute.Run(model);
            model.Start = model.End;
            return dist / model.Ms;
        }
    }
}
