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
        public char[,] Tiles { get; set; }
        protected Dictionary<(int, int), List<Enemy>> Enemies { get; }
        public (int X, int Y) Door { get; protected set; }
        public string NextMap { get; protected set; }
        protected Map(string name, int x, int y)
        {
            Name = name;
            Tiles = new char[x, y];
            Enemies = new Dictionary<(int, int), List<Enemy>>();
            InitializeMap();
        }
        protected abstract void InitializeMap();
        public void PrintMap()
        {
            Console.WriteLine($"{Name} 맵:");
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tiles.GetLength(0); x++)
                {
                    Console.Write(Tiles[x, y]);
                }
                Console.WriteLine();
            }
        }
        // 적 위치
        public List<Enemy> GetEnemiesAtPosition(int x, int y)
        {
            if (Enemies.ContainsKey((x, y)))
            {
                var enemies = Enemies[(x, y)];
                Enemies.Remove((x, y));
                return enemies;
            }
            return new List<Enemy>();
        }

        public bool IsDoor(int x, int y)
        {
            return x == Door.X && y == Door.Y;
        }
    }
}
