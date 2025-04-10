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
            Player bandit = new Player("도적", 20, 0, 5, 2); // 플레이어
            string currentMap = "마을";   // 현재 지역
            Map ruins = new Ruins(); // TODO 적이 맵다른곳 갔다오면 리젠됨 메인에서 선언후 픽스예정
            Map crypt = new Crypt();
            Map currentLocation = null;  // 현재 위치

            while (bandit.IsAlive())
            {
                switch (currentMap)
                {
                    case "마을":
                        currentMap = Village.ShowVillage(bandit);
                        break;

                    case "던전":
                        if (currentLocation == null)
                            currentLocation = new Ruins();

                        bandit.X = 1;
                        bandit.Y = 1;
                        currentLocation.Tiles[bandit.X, bandit.Y] = 'P';

                        bool exploring = true;
                        while (exploring)
                        {
                            Console.Clear();
                            currentLocation.PrintMap();
                            Console.WriteLine("방향키로 이동하세요.");

                            var key = Console.ReadKey(true).Key;
                            if (bandit.Move(key, currentLocation.Tiles))
                            {
                                var enemies = currentLocation.GetEnemiesPos(bandit.X, bandit.Y);
                                if (enemies.Count > 0)
                                {
                                    Battle battle = new Battle(bandit, enemies);
                                    battle.StartBattle();

                                    if (!bandit.IsAlive())
                                    {
                                        currentMap = "마을";
                                        currentLocation = null;
                                        break;
                                    }
                                }

                                // 문에 도달했을 때 다음 맵으로 이동
                                var door = currentLocation.GetDoorPos();
                                if (bandit.X == door.X && bandit.Y == door.Y)
                                {
                                    if (currentLocation is Ruins)
                                        currentLocation = new Crypt();
                                    else if (currentLocation is Crypt)
                                        currentLocation = new Ruins();
                                }

                                // 두 던전 모두 클리어 확인
                                if (new Ruins().IsCleared() && new Crypt().IsCleared())
                                {
                                    Console.Clear();
                                    Console.WriteLine("모든 던전을 클리어했습니다!");
                                    Console.ReadKey();
                                    currentMap = "마을";
                                    currentLocation = null;
                                    exploring = false;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}

