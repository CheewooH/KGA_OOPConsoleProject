using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public abstract class Map
    {
        // 다키스트 던전의 복도를 제거하고 심플하게 방만 연결 양방향 그래프로 될거같음
        // 필요한 기능
        // 방 추가 및 연결 시작 방 선정
        public string Name { get; }
        // 방 딕셔너리 선언 내부 적, 연결된 곳
        public Dictionary<string, (List<Enemy> enemies,List<string> connections)> Rooms { get; }
        public string StartingRoom { get; set; }
        protected Map(string name)
        {
            Name = name;
            Rooms = new Dictionary<string, (List<Enemy> enemies, List<string> connections)>();
            InitializeRooms();
        }
        protected abstract void InitializeRooms();
    }
}
