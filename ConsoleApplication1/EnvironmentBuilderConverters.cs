using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleApplication1.Enum;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    public class EnvironmentBuilderConverters
    {
        public LocationType GetLocationType(string type)
        {
            int num = 0;

            if (int.TryParse(type, out num))
            {
                return (LocationType)num;
            }
            else
            {
                return LocationType.Default;
            }
        }

        public CartesianPointer GetGlobalPointer(CartesianSize blockSize, CartesianPointer position,
            CartesianSize mapSize, CartesianSize matrixSize,
            CartesianPointer center, int x, int y)
        {
            var deslocamentoLocal = new CartesianPointer(x - center.X, y - center.Y);
            var porcentagem = new CartesianSize(mapSize.SizeX / matrixSize.SizeX, mapSize.SizeY / matrixSize.SizeY);
            var deslocamentoGlobal = new CartesianPointer(deslocamentoLocal.X * porcentagem.SizeX, deslocamentoLocal.Y * porcentagem.SizeY);
            var ponto = new CartesianPointer(deslocamentoGlobal.X + position.X, deslocamentoGlobal.Y + position.Y);
            var pontoCentral = new CartesianPointer(ponto.X + blockSize.SizeX / 2.0,
                ponto.Y + blockSize.SizeY / 2.0);
            return pontoCentral;
        }
        public CartesianSize GetMatrixSize(string map)
        {
            var line = map.Split(';')[1];
            var r = Regex.Matches(line, @"X[\s]{0,}=[\s]{0,}([0-9]{1,}), Y[\s]{0,}=[\s]{0,}([0-9]{1,})");
            if (r.Count > 0)
            {
                var v1 = double.Parse(r[0].Groups[1].Value);
                var v2 = double.Parse(r[0].Groups[2].Value);
                return new CartesianSize(v1, v2);
            }
            return null;
        }
        public LocationType[,] GetMapArray(string map, CartesianSize size)
        {
            var line = map
                .Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList()
                .Skip(2)
                .ToList();

            var regex = new Regex(@"[A-Z0-9\s]{1,}");

            var mat = new string[line.Count][];

            for (var x = 0; x < line.Count; x++)
            {
                mat[x] = line[x]
                    .Split('|')
                    .Where(p => regex.IsMatch(p))
                    .ToArray()
                    .Skip(1)
                    .ToArray();
            }

            var realMat = new LocationType[(int)size.SizeX, (int)size.SizeY];

            for (int x = 0; x < size.SizeX; x++)
            {
                for (int y = 0; y < size.SizeY; y++)
                {
                    realMat[x, y] = GetLocationType(mat[y][x]);
                }
            }
            return realMat;
        }
        public string GetMapName(string map)
        {
            var line = map.Split(';')[0];
            var r = Regex.Matches(line, @"Name[\s]{0,}=[\s]{0,}([a-zA-Z_0-9]{1,})");
            if (r.Count > 0)
            {
                return r[0].Groups[1].Value;
            }
            return string.Empty;
        }
        public CartesianSize GetBlockSize(CartesianSize size, CartesianSize matrixSize)
        {
            return new CartesianSize(size.SizeX / matrixSize.SizeX, size.SizeY / matrixSize.SizeY);
        }
    }
}
