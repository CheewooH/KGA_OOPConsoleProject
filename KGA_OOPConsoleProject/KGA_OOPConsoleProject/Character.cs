namespace KGA_OOPConsoleProject
{
    public abstract class Character
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
        public double Dodge { get; set; }
        public double Critical { get; set; }

        private static Random random = new Random();
        public Character(string name, int maxHp, double dodge = 0.1, double critical = 0.15)
        {
            Name = name;
            Hp = maxHp;
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
        public bool IsAlive()
        {
            return Hp > 0;
        }
    }
}
