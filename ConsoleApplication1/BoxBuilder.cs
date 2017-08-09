using System;
using ConsoleApplication1.Enum;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    public static class BoxBuilder
    {
        public static Box Create(BoxType type)
        {
            switch (type)
            {
                case BoxType.Litrinho300ML:
                    return new Box(type, 0, 0, 0, 0);
                    
                case BoxType.Inteira600:
                    return new Box(type, 0, 0, 0, 0);

                case BoxType.Litrao1L:
                    return new Box(type, 0, 0, 0, 0);

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }            
        }
    }
}