using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Player : Character
    {
        public int Stress { get; set; }

        public Player(string name, int maxHp, int stress, double dodge = 0.1, double critical = 0.15)
            : base(name, maxHp, dodge, critical)
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
    }
}
