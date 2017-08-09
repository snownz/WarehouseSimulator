using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Enum;

namespace ConsoleApplication1.Model
{
    public class Location : ObjectBase
    {
        private IList<Pallet> _pallets;

        public Location(IList<Pallet> pallets)
        {
            _pallets = pallets ?? new List<Pallet>();
        }
        public Location()
        {

        }

        public void AddPallet(Pallet pallet)
        {
            _pallets.Add(pallet);
        }

        public LocationType LocationType { get; set; }
        public double Capacity { get; set; }
        public double Occupation { get; set; }
    }
}
