using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Battle
    {
        private Player player;
        private List<Enemy> enemies;

        public Battle(Player player, List<Enemy> enemies)
        {
            this.player = player;
            this.enemies = enemies;
        }
        // TODO 아직 미구현
    }
}
