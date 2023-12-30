using System.Security.Cryptography.X509Certificates;

namespace RtanTextDungeon
{
    

    class Player
    {
        public int lv;
        public string name;
        public Define.PlayerClass m_class;
        public int atk;
        public int def;
        public int hp;
        public int gold;

        public Weapon? weapon = null;
        public Armor? armor = null;

        public List<Item> items = new List<Item>();

        public Player(Define.PlayerClass playerClass, Item item1, Item item2)
        {
            lv = 1;
            name = "르탄이";
            m_class = playerClass;
            atk = 10;
            def = 5;
            hp = 100;
            gold = 1500;

            items.Add(item1);
            items.Add(item2);            
        }
        
        public void EquipOrUnequipItem(int index)
        {
            Item item = items[index];
            Weapon? isWeapon = item as Weapon;
            
            // 선택한 아이템이 무기일 때
            if(isWeapon != null)
            {
                // 현재 무기가 없으면 장착
                if (weapon == null)
                    item.EquipItem(this);
                else
                {
                    item.UnequipItem(this);

                }                    
            }
        }
    }

    internal class Program
    {
        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※스파르타 던전 마을에 온 것을 환영합니다.※※※");
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(1) : [상태]\n(2) : [인벤토리]\n(3) : [상점]\n");

                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Status(ref player);
                        break;
                    case '2':
                        Console.Clear();
                        Inventory(ref player);
                        break;
                    case '3':
                        Console.Clear();
                        Shop(ref player);
                        break;
                    case '4':
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
                Console.WriteLine("============[상태 창]============");
                Console.ResetColor();

                Console.WriteLine("---------------------------------\n");
                Console.WriteLine($"Lv. {player.lv.ToString("00")}\n" +
                                $"이름\t:  {player.name}({player.m_class})\n\n" +
                                $"공격력\t:  {player.atk}\n" +
                                $"방어력\t:  {player.def}\n" +
                                $"체 력\t:  {player.hp}\n" +
                                $"Gold\t:  {player.gold}\n");
                Console.WriteLine("---------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(1) : [인벤토리]\n(2) : [상점]\n(3) : [마을로 돌아가기]\n");

                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Inventory(ref player);
                        return;
                    case '2':
                        Console.Clear();
                        Shop(ref player);
                        return;
                    case '3':
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
                Console.WriteLine("============[인벤토리]============");
                Console.ResetColor();

                Console.WriteLine("---------------------------------\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("[아이템 목록]");
                Console.ResetColor();
                // 아이템 목록은 아이템 리스트에 있는 아이템들을 전부 불러와야겠지?

                Console.WriteLine("---------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(1) : [상태]\n(2) : [상점]\n(3) : [마을로 돌아가기]\n");

                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Status(ref player);
                        return;
                    case '2':
                        Console.Clear();
                        Shop(ref player);
                        return;
                    case '3':
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
                Console.WriteLine("============[상   점]============");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(1) : [상태]\n(2) : [인벤토리]\n(3) : [마을로 돌아가기]\n");

                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Status(ref player);
                        return;
                    case '2':
                        Console.Clear();
                        Inventory(ref player);
                        return;
                    case '3':
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
            Player player = new Player(Define.PlayerClass.Worrior, new Weapon(10, "낡은 검"), new Armor(5, "가죽 옷"));            

            EnterGame(ref player);
        }
    }
}
