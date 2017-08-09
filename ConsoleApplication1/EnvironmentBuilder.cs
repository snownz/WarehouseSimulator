using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Enum;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    public class EnvironmentBuilder
    {
        private static Random _rd = new Random();
        private EnvironmentBuilderConverters _converter;

        private VirtualEnvironment _env;
        private Dictionary<string, Location[]> _locations;
        private string _currentMap;

        private Location[] getLocations(CartesianPointer position, CartesianSize mapSize, string map, int minCapacity, int maxCapacity)
        {
            var locations = new List<Location>();

            var matrixSize = _converter.GetMatrixSize(map);
            var blockSize = _converter.GetBlockSize(mapSize, matrixSize);
            var mapArray = _converter.GetMapArray(map, matrixSize);
            var center = new CartesianPointer(matrixSize.SizeX / 2.0, matrixSize.SizeY / 2.0);

            for (var x = 0; x < matrixSize.SizeX; x++)
            {
                for (var y = 0; y < matrixSize.SizeY; y++)
                {
                    if (mapArray[x, y] != LocationType.Default)
                    {
                        var pontoCentral = _converter.GetGlobalPointer(blockSize, position, mapSize, matrixSize, center, x, y);
                        var l = new Location
                        {
                            Size = blockSize,
                            Capacity = _rd.Next(minCapacity, maxCapacity),
                            LocationType = mapArray[x, y],
                            Occupation = 0,
                            Position = pontoCentral
                        };
                        if (l.Inside(_env))
                            locations.Add(l);
                    }
                }
            }
            return locations.ToArray();
        }
        private void GenerateRandomPalletsForLocationList(IList<BoxType> boxTypes, int minPallet, int maxPallet, IList<Location> loc)
        {
            foreach (var location in loc)
            {
                var qtdPallets = _rd.Next(minPallet, maxPallet + 1);
                for (int i = 0; i < qtdPallets; i++)
                {
                    var tipoCaixa = _rd.Next(0, boxTypes.Count);
                    var pallet = new PalletBuilder()
                        .WithBoxType(boxTypes[tipoCaixa])
                        .Create();
                    location.AddPallet(pallet);
                }
            }
        }

        public EnvironmentBuilder(CartesianSize size)
        {
            _env = new VirtualEnvironment(size);
            _converter = new EnvironmentBuilderConverters();
        }

        public EnvironmentBuilder PlotMap(string map, CartesianSize size, CartesianPointer position)
        {
            _currentMap = _converter.GetMapName(map);
            _locations.Add(_currentMap, getLocations(position, size, map, 0, 2));
            return this;
        }

        public Pallet WithFullPallet(BoxType boxType)
        {
            var pallet = new PalletBuilder().WithBoxType(boxType).Create();
            return pallet;
        }

        public EnvironmentBuilder WithRandomPalletsIntoAllLocations(IList<BoxType> boxTypes, int minPallet, int maxPallet)
        {
            var loc = _locations[_currentMap];
            GenerateRandomPalletsForLocationList(boxTypes, minPallet, maxPallet, loc);
            return this;
        }

        public EnvironmentBuilder WithRandomPalletsIntoSpecificLocationType(IList<BoxType> boxTypes, int minPallet, int maxPallet, LocationType type)
        {
            var loc = _locations[_currentMap].Where(x => x.LocationType == type).ToList();
            GenerateRandomPalletsForLocationList(boxTypes, minPallet, maxPallet, loc);
            return this;
        }

        public EnvironmentBuilder WithPalletTypeWithSpecificBoxType(BoxType boxType, int minPallet, int maxPallet, int location)
        {
            var pallet = new PalletBuilder()
                .WithBoxType(boxType)
                .Create();

            _locations[_currentMap][location].AddPallet(pallet);
            return this;
        }

        public EnvironmentBuilder AddHelpers(Helpers[] _helpers)
        {
            return this;
        }
        public EnvironmentBuilder AddHelpers(Helpers _helper)
        {
            return this;
        }
        public VirtualEnvironment Build()
        {
            return _env;
        }

    }
}
