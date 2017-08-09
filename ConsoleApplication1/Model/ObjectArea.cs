using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    public class ObjectArea
    {
        public ObjectArea(CartesianPointer fp, CartesianPointer sp)
        {
            LeftPointer = fp;
            RightPointer = sp;
        }

        public CartesianPointer LeftPointer { get; set; }
        public CartesianPointer RightPointer { get; set; }
    }
}
