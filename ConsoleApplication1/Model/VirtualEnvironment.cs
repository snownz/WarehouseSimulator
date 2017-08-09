using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    public class VirtualEnvironment : ObjectBase
    {
        private IList<Helpers> _helpers;
        private IList<Area> _areas;
        public VirtualEnvironment(CartesianSize size)
        {
            Size = size;
            Position = new CartesianPointer(0, 0);
        }
    }
}
