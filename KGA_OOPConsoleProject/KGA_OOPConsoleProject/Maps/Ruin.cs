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
        }

        protected override void InitializeMap()
        { // TODO 임시 펙토리만들면 다시오자
            // 빈공간 : . 벽 : # 플레이어 : P 적 : E
            for (int y = 0; y < Size.GetLength(1); y++)
            {
                for (int x = 0; x < Size.GetLength(0); x++)
                {
                    if (y == 0 || y == Size.GetLength(1) - 1 || x == 0 || x == Size.GetLength(0) - 1)
                        Size[x, y] = '#';
                    else
                        Size[x, y] = '.';
                }
            }
            // TODO 적배치, 배치 하나에 적 둘 나오게 하는법 찾아보기, 스택으로 전투진입?
            
        }
    }
}
