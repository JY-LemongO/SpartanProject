namespace RtanTextDungeon
{
    public enum PlayerClass
    {
        Worrior,
        Archer,
        Magic,
        Thief,
    }

    internal class Program
    {
        struct Player
        {
            public int lv;
            public string name;
            public PlayerClass m_class;
            public int atk;
            public int def;
            public int hp;
            public int gold;
        }

        static void CharacterCreate(ref Player player)
        {
            player.lv = 1;
            player.name = "십칠조";
            player.m_class = PlayerClass.Worrior;
            player.atk = 10;
            player.def = 5;
            player.hp = 100;
            player.gold = 1500;
        }

        static void SelectAction(ref Player player)
        {
            while (true)
            {                
                Console.WriteLine("※※※17초 던전 마을에 온 것을 환영합니다.※※※");
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.WriteLine("(1) : [상태]\n(2) : [인벤토리]\n(3) : [상점]\n");                

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Status(ref player);
                        break;
                    case "2":
                        Console.Clear();
                        Inventory(ref player);
                        break;
                    case "3":
                        Console.Clear();
                        Shop(ref player);
                        break;
                    case "4":                        
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("※※※게임을 종료합니다※※※");
                        Console.ResetColor();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!!!잘못된 입력입니다!!!");
                        Console.ResetColor();
                        break;
                }
            }                   
        }

        static void Status(ref Player player)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[상태 창]\n");
                Console.ResetColor();

                Console.WriteLine("---------------------------------\n");
                Console.WriteLine($"Lv. {player.lv.ToString("00")}\n\n" +
                                $"{player.name} ({player.m_class})\n" +
                                $"공격력 : {player.atk}\n" +
                                $"방어력 : {player.def}\n" +
                                $"체 력 : {player.hp}\n" +
                                $"Gold : {player.gold}\n");
                Console.WriteLine("---------------------------------\n");

                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.WriteLine("(1) : [인벤토리]\n(2) : [상점]\n(3) : [마을로 돌아가기]\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Inventory(ref player);
                        return;
                    case "2":
                        Console.Clear();
                        Shop(ref player);
                        return;
                    case "3":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!!!잘못된 입력입니다!!!");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void Inventory(ref Player player)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[인벤토리]\n");
                Console.ResetColor();

                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.WriteLine("(1) : [상태]\n(2) : [상점]\n(3) : [마을로 돌아가기]\n");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Status(ref player);
                        return;
                    case "2":
                        Console.Clear();
                        Shop(ref player);
                        return;
                    case "3":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!!!잘못된 입력입니다!!!");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void Shop(ref Player player)
        {
            while (true)
            {                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[상점]\n");
                Console.ResetColor();

                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.WriteLine("(1) : [상태]\n(2) : [인벤토리]\n(3) : [마을로 돌아가기]\n");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Status(ref player);
                        return;
                    case "2":
                        Console.Clear();
                        Inventory(ref player);
                        return;
                    case "3":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!!!잘못된 입력입니다!!!");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            CharacterCreate(ref player);

            SelectAction(ref player);
        }
    }
}
