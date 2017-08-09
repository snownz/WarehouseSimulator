using System;
using ConsoleApplication1.Enum;
using ConsoleApplication1.Model;

namespace ConsoleApplication1.Actions
{
    public interface IAction<T>
    {
        T Run();
    }

    public interface IAction<T, K>
        where K : IActionModel
    {
        T Run(K model, Npc npc, double score);
        T Run(K model);
    }

    public class Action : IAction<int, ActionModelBuildPallet>
    {
        private readonly IAction<int, ActionModelGetBoxFromLocation> _getBox;
        private readonly IAction<int, ActionModelFinishPallet> _finishPalletBuild;
        private readonly IAction<Location, ActionModelFindBoxLocation> _findBoxLocation;
        private readonly IAction<Location, ActionModelFindFreeLocation> _findFreeTCLocation;

        public Action(
            IAction<int, ActionModelGetBoxFromLocation> getBox,
            IAction<int, ActionModelFinishPallet> finishPalletBuild,
            IAction<Location, ActionModelFindBoxLocation> findBoxLocation,
            IAction<Location, ActionModelFindFreeLocation> findFreeTcLocation)
        {
            _getBox = getBox;
            _finishPalletBuild = finishPalletBuild;
            _findBoxLocation = findBoxLocation;
            _findFreeTCLocation = findFreeTcLocation;
        }

        public int Run(ActionModelBuildPallet model, Npc npc, double score)
        {
            var timeSpent = 0;
            var pallet = new Pallet();

            foreach (var box in model.Boxes)
            {
                var location = _findBoxLocation.Run(new ActionModelFindBoxLocation() { BoxType = box.Key });

                timeSpent += npc.Move.Run(new ActionModelMoveToLocation()
                {
                    AvarageSpeed = npc.Ms,
                    CurrentLocation = npc.Position,
                    To = location.Position,
                    PayLoad = pallet.Weight
                });

                timeSpent += _getBox.Run(new ActionModelGetBoxFromLocation()
                {
                    Location = location,
                    CurrentLocation = npc.Position,
                    Pallet = pallet,
                    Quantity = box.Value
                });
            }

            var tcLocation = _findFreeTCLocation.Run(new ActionModelFindFreeLocation() { LocationType = LocationType.TC });

            timeSpent += _finishPalletBuild.Run(new ActionModelFinishPallet() { Location = tcLocation, Pallet = pallet });

            return timeSpent;
        }
        public int Run(ActionModelBuildPallet model)
        {
            throw new NotImplementedException();
        }
    }
}
