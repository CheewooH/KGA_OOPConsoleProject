using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Maps
{
    public class Crypt : Map
    {
        public Crypt() : base("묘지", 7, 5)
        {
            Door = (1, 2);
        }

        protected override void InitializeMap()
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tiles.GetLength(0); x++)
                {
                    if (y == 0 || y == Tiles.GetLength(1) - 1 || x == 0 || x == Tiles.GetLength(0) - 1)
                        Tiles[x, y] = '#';
                    else
                        Tiles[x, y] = ' ';
                }
            }

            Tiles[3, 3] = 'E';
            Enemies[(3, 3)] = new List<Enemy> { new Enemy("좀비", 12, 6, 4) };

            Tiles[Door.X, Door.Y] = 'D';
        }
    }
}
