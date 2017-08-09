using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Enum;

namespace ConsoleApplication1.Model
{
    public class Pallet : ObjectBase
    {
        private IList<Box> _boxs;
        public double Occupation { get { return _boxs?.Sum(x => x.GetPercentualOcupationPallet(this)) ?? 0; } }
        public double Weight => _boxs.Sum(x => x.Weight);

        private readonly double _z;

        public Pallet(IList<Box> boxs)
        {
            _boxs = boxs;
        }

        public Pallet()
        {
            _boxs = new List<Box>();
        }

        public double GetVolume()
        {
            return _z * Size.SizeX * Size.SizeY;
        }

        public bool AddBox(Box box)
        {
            if (1 - Occupation >= box.GetPercentualOcupationPallet(this))
            {
                _boxs.Add(box);
                return true;
            }
            return false;
        }
    }
}
