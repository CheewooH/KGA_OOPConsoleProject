using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Enemy : Character
    {
        public Enemy(string name, int maxHp, double dodge = 0.1, double critical = 0.15)
            : base(name, maxHp, dodge, critical)
        {

        }
    }
}
