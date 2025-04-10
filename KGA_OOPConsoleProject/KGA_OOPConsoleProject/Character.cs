namespace KGA_OOPConsoleProject
{
    public abstract class Character
    {
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
        public int Attack { get; set; }
        public int Defense { get; set; }

        private static Random random = new Random();
        public Character(string name, int maxHp, int attack, int defense, double dodge = 0.1, double critical = 0.15)
        {
            Name = name;
            Hp = maxHp;
            Attack = attack;
            Defense = defense;
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
            int reducedDamage = Math.Max(damage - Defense, 0); // Math.Max 두개의 값중 큰값을 반환하는 함수
            Hp -= damage;
        }
        public bool IsAlive()
        {
            return Hp > 0;
        }
    }
}
