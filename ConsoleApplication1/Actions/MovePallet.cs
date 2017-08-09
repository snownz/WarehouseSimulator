using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Model;

namespace ConsoleApplication1.Actions
{
    public class MovePallet : IActionModel
    {
        public CartesianPointer Start { get; set; }
        public CartesianPointer End { get; set; }
        public Pallet Pallet { get; set; }
    }
}
