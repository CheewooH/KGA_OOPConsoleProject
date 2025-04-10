using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Player : Character
    {
        public int Stress { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Player(string name, int maxHp, int stress, int attack, int defense, double dodge = 0.1, double criticalChance = 0.15)
            : base(name, maxHp, attack, defense, dodge, criticalChance)
        {
            Stress = stress;
        }

        public void AddStress(int stress)
        {
            Stress += stress;
            if (Stress > 100)
            {
                Stress = 100;
                HP = 1;
                Console.WriteLine($"{Name}의 스트레스가 한계치에 도달했습니다!");
                Console.WriteLine("죽음의 문턱");
            }
            Console.WriteLine($"{Name}의 스트레스: {Stress}");
        }
        public bool Move(ConsoleKey key, char[,] tiles)
        {
            int X = this.X;
            int Y = this.Y;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                    X++;
                    break;
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                default:
                    return false;
            }
            // 맵 밖으로 못나가게
            if (X >= 0 && Y >= 0 && X < tiles.GetLength(0) && Y < tiles.GetLength(1))
            {
                if (tiles[X, Y] == '#')
                    return false;
            }
            else
            {
                return false;
            }

            tiles[this.X, this.Y] = ' '; // 이전 위치 복구
            this.X = X;
            this.Y = Y;
            tiles[this.X, this.Y] = 'P'; // 플레이어 이동
            return true;
        }
    }
}
