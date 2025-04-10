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

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("전투 시작!");

            int turn = 1;

            while (player.IsAlive() && enemies.Any(e => e.IsAlive()))
            {
                Console.WriteLine($"\n=== 턴 {turn} ===");
                ShowStatus();

                Console.WriteLine("\n행동을 선택하세요:");
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬1 (미구현)");
                Console.WriteLine("3. 스킬2 (미구현)");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PlayerAttack();
                        break;
                    default:
                        Console.WriteLine("스킬은 아직 사용할 수 없습니다!");
                        break;
                }

                EnemyTurn();
                turn++;
                Console.ReadKey();
                Console.Clear();
            }

            if (player.IsAlive())
                Console.WriteLine("전투에서 승리했습니다!");
            else
                Console.WriteLine("플레이어가 사망했습니다...");
        }

        private void ShowStatus()
        {
            Console.WriteLine($"{player.Name} HP: {player.HP}");
            for (int i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];
                Console.WriteLine($"[{i}] {enemy.Name} HP: {enemy.HP}");
            }
        }

        private void PlayerAttack()
        {
            Console.WriteLine("공격할 적 번호를 입력하세요:");
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IsAlive())
                    Console.WriteLine($"{i}: {enemies[i].Name} (HP: {enemies[i].HP})");
            }

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice < enemies.Count)
            {
                var enemy = enemies[choice];
                if (enemy.IsAlive())
                {
                    bool isCritical = false;
                    int damage = player.Cirtical(player.Attack, ref isCritical);
                    enemy.TakeDamage(damage);
                    Console.WriteLine($"{enemy.Name}에게 {damage} 데미지를 입혔습니다.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        private void EnemyTurn()
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.IsAlive()) continue;

                bool isCritical = false;
                int damage = enemy.Cirtical(enemy.Attack, ref isCritical);
                Console.WriteLine($"{enemy.Name}의 공격!");
                player.TakeDamage(damage);
            }
        }
    }
}
