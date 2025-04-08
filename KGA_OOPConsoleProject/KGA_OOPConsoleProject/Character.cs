namespace KGA_OOPConsoleProject
{
    public class Character
    {
        // HP와 스트레스만 가지고 나머지 스탯은 장비로
        public string Name { get; set; }
        private int Hp;
        public int HP
        {
            get { return Hp; }
            set
            {
                Hp = value;
                if (Hp < 0)
                {
                    Hp = 0;
                }
            }
        }
        public int Stress { get; set; }
        public double Dodge { get; set; }
        public double Critical { get; set; }

        private static Random random = new Random();
        public Character(string name, int maxHp, int stress, double dodge = 0.1, double critical = 0.15)
        {
            Name = name;
            Hp = maxHp;
            Stress = stress;
            Dodge = dodge;
            Critical = critical;
        }
        public int Cirtical(int damage, ref bool isCritical)
        {
            if (random.NextDouble() < Critical)
            {
                isCritical = true;
                damage = (int)Math.Round(damage * 1.5);
                Console.WriteLine($"크리티컬!");
            }
            else
            {
                isCritical = false;
            }
            return damage;
        }

        
        public void TakeDamage(int damage)
        {
            if (random.NextDouble() < Dodge)
            {
                Console.WriteLine("회피했다!");
                return;
            }
            Hp -= damage;
            Console.WriteLine($"{damage}데미지를 받았다.");
        }
        public void AddStress(int stress)
        {
            Stress += stress;
                if (stress > 100)
            {
                stress = 100;
                Hp = 1;
                Console.WriteLine($"{Name}의 스트레스 가 한계치에 도달했습니다!");
                Console.WriteLine("죽음의 문턱");
            }
            Console.WriteLine($"{Name}의 스트레스 : {stress}");
        }
        public bool IsAlive()
        {
            return Hp > 0;
        }


    }
}
