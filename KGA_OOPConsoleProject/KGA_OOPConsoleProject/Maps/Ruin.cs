using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Maps
{
    public class Ruins : Map
    {
        public Ruins() : base("폐허")
        {
            StartingRoom = "입구";
        }

        protected override void InitializeRooms()
        { // TODO 임시 펙토리만들면 다시오자
            Rooms["입구"] = (new List<Enemy>(), new List<string> { "홀" });
            Rooms["홀"] = (new List<Enemy> { new Enemy("해골", 10, 5, 3) }, new List<string> { "입구", "묘실" });
            Rooms["묘실"] = (new List<Enemy> { new Enemy("해골 전사", 15, 7, 5) }, new List<string> { "홀" });
        }
    }
}
