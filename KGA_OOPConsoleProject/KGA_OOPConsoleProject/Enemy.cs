using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Enemy : Character
    {

        public Enemy(string name, int maxHp, int attack, int defense, double dodge = 0.1, double criticalChance = 0.15)
            : base(name, maxHp, attack, defense, dodge, criticalChance)
        {
           
        }
    }
}
