namespace KGA_OOPConsoleProject
{
    public class Character
    {
        // HP와 스트레스만 가지고 나머지 스탯은 장비로
        public string name { get; set; }
        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp < 0)
                {
                    hp = 0;
                }
            }
        }
        public int stress {  get; set; }
        public double dodge { get; set; }
        public int Cirtical(int damage, ref bool isCritical)
        {
            int critical = new Random().Next(1, 100);
            if (critical <= 15)
            { // 크리티컬일때
                isCritical = true;
                // TODO
            }
            else
            {
                isCritical = false;
            }

            return damage;

        }



    }
}
