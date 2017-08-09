using ConsoleApplication1.Enum;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    public class PalletBuilder
    {
        private BoxType _boxType;
        private CartesianSize _size;
        private double _z;

        public Pallet Create()
        {
            var pallet = new Pallet();

            var box = BoxBuilder.Create(_boxType);

            do
            {
                box = BoxBuilder.Create(_boxType);
            } while (pallet.AddBox(box));

            return pallet;
        }

        public PalletBuilder WithBoxType(BoxType type)
        {
            _boxType = type;
            return this;
        }
    }
}