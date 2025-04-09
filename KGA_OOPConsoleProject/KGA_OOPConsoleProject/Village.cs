using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Village
    {
        public static string ShowVillage(Player player)
        {
            Console.Clear();
            Console.WriteLine("=== 마을 ===");
            Console.WriteLine($"{player.Name} (HP: {player.HP}, 스트레스: {player.Stress})");
            Console.WriteLine("\n어디로 가시겠습니까?");
            Console.WriteLine("1. 성당  2. 던전");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n성당에서 기도드리며 마음을 안정시켰습니다.");
                    player.AddStress(-20);
                    Console.ReadKey();
                    return "마을";
                case "2":
                    return "던전";
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    Console.ReadKey();
                    return "마을";
            }
        }
    }
}
