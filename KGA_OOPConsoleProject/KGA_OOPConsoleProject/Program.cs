using KGA_OOPConsoleProject.Maps;

namespace KGA_OOPConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 다키스트 던전 을 텍스트 알피지형으로 만들어보자
            // 캐릭터, 적, 맵을 가지고 캐릭터의 스탯은 장비로
            // 체력은 던전이 끝나면 다시 리셋 스트레스는 유지
            // 마을은 텍스트로 하자
            Player bandit = new Player("도적", 20, 0, 5, 2);
            string currentLocation = "마을";
            Map currentMap = null;

            while (true)
            {
                if (currentLocation == "마을")
                {
                    currentLocation = Village.ShowVillage(bandit);
                    if (currentLocation == "종료")
                        break;
                    if (currentLocation == "던전")
                    {
                        currentMap = new Ruins();
                        bandit.X = 1;
                        bandit.Y = 1;
                        currentMap.Tiles[bandit.X, bandit.Y] = 'P';
                    }
                }
                else if (currentLocation == "던전")
                {
                    Console.Clear();
                    currentMap.PrintMap();

                    Console.WriteLine("\n이동 : 방향키");
                    var key = Console.ReadKey(true).Key;

                    if (bandit.Move(key, currentMap.Tiles))
                    {
                        if (currentMap.IsDoor(bandit.X, bandit.Y))
                        {
                            string nextMapName = currentMap.NextMap;
                            if (nextMapName == "폐허")
                            {
                                currentMap = new Ruins();
                                bandit.X = 1;
                                bandit.Y = 1;
                            }
                            else if (nextMapName == "묘지")
                            {
                                currentMap = new Crypt();
                                bandit.X = 1;
                                bandit.Y = 1;
                            }
                            currentMap.Tiles[bandit.X, bandit.Y] = 'P';
                            continue;
                        }
                    }
                }
            }
        }
    }
}
