using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Enum;

namespace ConsoleApplication1.Model
{
    public class Box : ObjectBase
    {
        public Box(BoxType type, double heigth, double width, double z, double weight)
        {
            Type = type;
            Size = new CartesianSize(width, heigth);
            _z = z;
            Weight = weight;
        }

        public double Weight { get; set; }
        public BoxType Type { get; set; }

        private readonly double _z;

        public double GetVolume()
        {
            return _z * Size.SizeX * Size.SizeY;
        }

        public double GetPercentualOcupationPallet(Pallet pallet)
        {
            return GetVolume() / pallet.GetVolume();
        }
    }
}
