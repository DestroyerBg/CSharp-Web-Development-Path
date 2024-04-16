namespace Problem_3___Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HP=hp;
            MP=mp;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public override string ToString()
        {
            return $"{Name}\n" +
                   $"  HP: {HP}\n" +
                   $"  MP: {MP}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes= int.Parse(Console.ReadLine());
            var heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] arguments= Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string heroName= arguments[0];
                int HP= int.Parse(arguments[1]);
                int MP= int.Parse(arguments[2]);
                if (HP>100)
                {
                    HP -= HP - 100;
                }

                if (MP > 200)
                {
                    MP -= MP - 200;
                }
                Hero hero= new Hero(heroName,HP,MP);
                heroes.Add(heroName,hero);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction= arguments[0];
                if (instruction == "CastSpell")
                {
                    string name= arguments[1];
                    int MPNeed= int.Parse(arguments[2]);
                    string spellName= arguments[3];
                    heroes = CastSpell(name,MPNeed,spellName,heroes);
                }
                else if (instruction == "TakeDamage")
                {
                    string name= arguments[1];
                    int damage= int.Parse(arguments[2]);
                    string attacked = arguments[3];
                    heroes=TakeDamage(name, damage, attacked,heroes);
                }
                else if (instruction == "Recharge")
                {
                    string name = arguments[1];
                    int amount = int.Parse(arguments[2]);
                    heroes=Recharge(name, amount,heroes);
                }
                else if (instruction == "Heal")
                {
                    string name = arguments[1];
                    int amount = int.Parse(arguments[2]);
                    heroes=Heal(name, amount,heroes);
                }

            }

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Value.ToString()}");
            }
        }

        private static Dictionary<string, Hero> Heal(string name, int amount, Dictionary<string, Hero> heroes)
        {
            int currHealth = heroes[name].HP;
            heroes[name].HP += amount;
            if (heroes[name].HP > 100)
            {
                heroes[name].HP = 100;
                Console.WriteLine($"{name} healed for {heroes[name].HP-currHealth} HP!");
            }
            else
            {
                Console.WriteLine($"{name} healed for {amount} HP!");
            }
            return heroes;
        }

        private static Dictionary<string, Hero> Recharge(string name, int amount, Dictionary<string, Hero> heroes)
        {
            int currMana = heroes[name].MP;
            heroes[name].MP += amount;
            if (heroes[name].MP>200)
            {
                heroes[name].MP = 200;
                Console.WriteLine($"{name} recharged for {200-currMana} MP!");
            }
            else
            {
                Console.WriteLine($"{name} recharged for {amount} MP!");
            }
            return heroes;
        }

        private static Dictionary<string, Hero> TakeDamage(string name, int damage, string attacker,
            Dictionary<string, Hero> heroes)
        {
            heroes[name].HP-=damage;
            if (heroes[name].HP>0)
            {
                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
                return heroes;
            }
            else
            {
                heroes.Remove(name);
                Console.WriteLine($"{name} has been killed by {attacker}!");
                return heroes;
            }
        }

        private static Dictionary<string,Hero> CastSpell(string name, int mpNeed, string spellName, Dictionary<string, Hero> heroes)
        {
            if (heroes[name].MP>=mpNeed)
            {
                heroes[name].MP -= mpNeed;
                Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].MP} MP!");
                return heroes;
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                return heroes;
            }
        }
    }
}