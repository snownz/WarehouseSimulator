using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    public class CartesianSize
    {
        public CartesianSize(double v1, double v2)
        {
            this.SizeX = v1;
            this.SizeY = v2;
        }

        public CartesianSize()
        {
        }

        public double SizeX { get; set; }
        public double SizeY { get; set; }
    }
}
