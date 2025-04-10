using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Maps
{
    public class Ruins : Map
    {
        public Ruins() : base("폐허",7,5)
        {
            Door = (6, 2);
            NextMap = "지하실";
            beforeMap = null;
            InitializeMap();
        }

        protected override void InitializeMap()
        {
            // 빈공간 : . 벽 : # 플레이어 : P 적 : E 문 : D
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
            Tiles[3, 1] = 'E';
            Enemies[(3, 1)] = new List<Enemy> { new Enemy("해골", 10, 5, 3), new Enemy("해골", 10, 5, 3) };

            Tiles[5, 3] = 'E';
            Enemies[(5, 3)] = new List<Enemy> { new Enemy("해골 전사", 15, 7, 5), new Enemy("해골", 10, 5, 3) };

            Tiles[Door.X, Door.Y] = 'D';
        }
    }
}
