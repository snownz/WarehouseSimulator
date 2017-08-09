using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    public class ObjectBase
    {
        public string Id { get; set; }
        private CartesianPointer _position;
        private CartesianSize _size;
        private string _mainThreadId;

        public CartesianPointer Position
        {
            get { return _position; }
            set
            {
                _position = value;
                SimulatorGlobalVariables.GeCurrentTime(_mainThreadId);
            }
        }

        public CartesianSize Size
        {
            get { return _size; }
            set
            {
                _size = value;
                SimulatorGlobalVariables.GeCurrentTime(_mainThreadId);
            }
        }

        public ObjectArea MathSquareArea()
        {
            var fp = new CartesianPointer(Position.X - (Size.SizeX / 2), Position.Y - (Size.SizeY / 2));
            var sp = new CartesianPointer(Position.X + (Size.SizeX / 2), Position.Y + (Size.SizeY / 2));
            return new ObjectArea(fp, sp);
        }
        public bool Inside(ObjectBase obj)
        {
            var area = obj.MathSquareArea();
            return (Position.X > area.LeftPointer.X && Position.X < area.RightPointer.X) &&
                   (Position.Y > area.LeftPointer.Y && Position.X < area.RightPointer.Y);
        }
        public bool Collid(ObjectBase obj)
        {
            return false;
        }
    }
}
