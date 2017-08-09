using System;
using System.Collections.Generic;
using ConsoleApplication1.Enum;
using ConsoleApplication1.Model;

namespace ConsoleApplication1.Actions
{
    public interface IActionModel
    {
        CartesianPointer CurrentLocation { get; set; }
    }

    public class ActionModelBuildPallet : IActionModel
    {
        public double Complexity => 0.0;
        public Dictionary<BoxType, int> Boxes { get; set; }
        public CartesianPointer CurrentLocation { get; set; }
    }

    public class ActionModelMoveToLocation : IActionModel
    {        
        public double AvarageSpeed { get; set; }
        public double PayLoad { get; set; }
        public CartesianPointer To { get; set; }
        public CartesianPointer CurrentLocation { get; set; }
    }

    public class ActionModelGetBoxFromLocation : IActionModel
    {
        public CartesianPointer CurrentLocation { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }
        public Pallet Pallet { get; set; }
    }

    public class ActionModelFinishPallet : IActionModel
    {
        public CartesianPointer CurrentLocation { get; set; }
        public Location Location { get; set; }
        public Pallet Pallet { get; set; }        
    }

    public class ActionModelFindBoxLocation : IActionModel
    {
        public CartesianPointer CurrentLocation { get; set; }
        public BoxType BoxType { get; set; }
    }

    public class ActionModelFindFreeLocation : IActionModel
    {
        public CartesianPointer CurrentLocation { get; set; }
        public LocationType LocationType { get; set; }
    }
}
