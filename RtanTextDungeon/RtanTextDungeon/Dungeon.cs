using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanTextDungeon
{
    internal class Dungeon
    {
        private Shop? shop;

        public void EnterGame(Player player, Shop shop)
        {
            if (this.shop == null)
                this.shop = shop;

            while (true)
            {
                Console.WriteLine("===============================================================================================");
                Console.WriteLine(" _______                      __            _____                                              ");
                Console.WriteLine("|     __|.-----..---.-..----.|  |_ .---.-. |     \\ .--.--..-----..-----..-----..-----..-----. ");
                Console.WriteLine("|__     ||  _  ||  _  ||   _||   _||  _  | |  --  ||  |  ||     ||  _  ||  -__||  _  ||     |  ");
                Console.WriteLine("|_______||   __||___._||__|  |____||___._| |_____/ |_____||__|__||___  ||_____||_____||__|__|  ");
                Console.WriteLine("         |__|                                                    |_____|                       ");
                Console.WriteLine("===============================================================================================\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※스파르타 던전 마을에 온 것을 환영합니다.※※※");
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(E) : [상태]\n\n(I) : [인벤토리]\n\n(S) : [상점]\n\n(X) : [게임종료]\n");

                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case 'E':
                    case 'e':
                        Console.Clear();
                        Status(player);
                        break;
                    case 'I':
                    case 'i':
                        Console.Clear();
                        Inventory(player);
                        break;
                    case 'S':
                    case 's':
                        Console.Clear();
                        Shop(player);
                        break;
                    case 'X':
                    case 'x':
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

        private void Status(Player player)
        {
            string weaponStatus = player.equippedItems.ContainsKey(typeof(Weapon)) ? player.equippedItems[typeof(Weapon)].AdditionalValue : "";
            string armorStatus = player.equippedItems.ContainsKey(typeof(Armor)) ? player.equippedItems[typeof(Armor)].AdditionalValue : "";

            while (true)
            {
                Console.WriteLine(" _______  __           __                 ");
                Console.WriteLine("|     __||  |_ .---.-.|  |_ .--.--..-----.");
                Console.WriteLine("|__     ||   _||  _  ||   _||  |  ||__ --|");
                Console.WriteLine("|_______||____||___._||____||_____||_____|");                

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=================[상태 창]=================");
                Console.ResetColor();

                Console.WriteLine("-------------------------------------------\n");
                Console.WriteLine($"Lv. {player.lv.ToString("00")}\n" +
                                $"이름\t:  {player.name}({player.m_class})\n\n" +
                                $"공격력\t:  {player.atk} {weaponStatus}\n" +
                                $"방어력\t:  {player.def} {armorStatus}\n" +
                                $"체 력\t:  {player.hp}\n" +
                                $"Gold\t:  {player.gold:N0} G\n");
                Console.WriteLine("-------------------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(I) : [인벤토리]\n\n(S) : [상점]\n\n(B) : [마을로 돌아가기]\n\n");

                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case 'I':
                    case 'i':
                        Console.Clear();
                        Inventory(player);
                        return;
                    case 'S':
                    case 's':
                        Console.Clear();
                        Shop(player);
                        return;
                    case 'B':
                    case 'b':
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

        private void Inventory(Player player)
        {
            while (true)
            {
                Console.WriteLine(" _______                              __                       ");
                Console.WriteLine("|_     _|.-----..--.--..-----..-----.|  |_ .-----..----..--.--.");
                Console.WriteLine(" _|   |_ |     ||  |  ||  -__||     ||   _||  _  ||   _||  |  |");
                Console.WriteLine("|_______||__|__| \\___/ |_____||__|__||____||_____||__|  |___  |");
                Console.WriteLine("                                                        |_____|");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("============================[인벤토리]============================");
                Console.ResetColor();

                Console.WriteLine("------------------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("[아이템 목록]\n");
                Console.ResetColor();
                // 아이템 목록은 아이템 리스트에 있는 아이템들을 전부 불러와야겠지?

                int index = 1;
                foreach (Item item in player.items)
                {
                    if(item.IsEquip)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    if (item is Weapon weapon)
                        Console.WriteLine($"- ({index})  {weapon.Name}\t| {weapon.AbilityName} : +{weapon.damage}\t| {weapon.Desc}");
                    else if (item is Armor armor)
                        Console.WriteLine($"- ({index})  {armor.Name}\t| {armor.AbilityName} : +{armor.defense}\t| {armor.Desc}");
                    Console.ResetColor();
                    index++;
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(E) : [상태]\n\n(S) : [상점]\n\n(B) : [마을로 돌아가기]\n\n");

                string input = Console.ReadLine();
                int itemIndex;
                switch (input)
                {
                    case "E":
                    case "e":
                        Console.Clear();
                        Status(player);
                        return;
                    case "S":
                    case "s":
                        Console.Clear();
                        Shop(player);
                        return;
                    case "B":
                    case "b":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        if (int.TryParse(input, out itemIndex) && itemIndex <= player.items.Count && itemIndex > 0)
                        {
                            itemIndex--;
                            if (player.items[itemIndex] is Weapon weapon)
                                player.EquipOrUnequipItem(weapon);
                            else if (player.items[itemIndex] is Armor armor)
                                player.EquipOrUnequipItem(armor);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!!!잘못된 입력입니다!!!");
                            Console.ResetColor();
                        }
                        break;
                }
            }
        }

        private void Shop(Player player)
        {
            while (true)
            {
                Console.WriteLine(" _______  __                  ");
                Console.WriteLine("|     __||  |--..-----..-----.");
                Console.WriteLine("|__     ||     ||  _  ||  _  |");
                Console.WriteLine("|_______||__|__||_____||   __|");
                Console.WriteLine("                       |__|   ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("============[상   점]============");
                Console.ResetColor();
                Console.WriteLine("---------------------------------\n");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("[보유 골드]");
                Console.ResetColor();
                Console.WriteLine($"{player.gold:N0} G\n");
                
                Console.WriteLine("[아이템 목록]");
                int index = 1;
                foreach (Item item in shop.items)
                {
                    if (item.IsBuy)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"- ({index})\t{item.Name}\t| 구매완료 - 판매가격 : {(int)(item.Price * 0.85f)} G");
                        Console.ResetColor();
                    }                        
                    else if (item is Weapon weapon)
                        Console.WriteLine($"- ({index})\t{weapon.Name}\t| {weapon.AbilityName} : +{weapon.damage}\t| {weapon.Desc}\t| {weapon.Price:N0} G");
                    else if (item is Armor armor)
                        Console.WriteLine($"- ({index})\t{armor.Name}\t| {armor.AbilityName} : +{armor.defense}\t| {armor.Desc}\t| {armor.Price:N0} G");
                    index++;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("아이템 번호를 입력하시면 구매/판매가 가능합니다.\n");
                Console.ResetColor();

                Console.WriteLine("---------------------------------");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();
                Console.WriteLine("(E) : [상태]\n\n(I) : [인벤토리]\n\n(B) : [마을로 돌아가기]\n\n");

                string input = Console.ReadLine();
                int itemIndex;                
                switch (input)
                {                    
                    case "E":
                    case "e":
                        Console.Clear();
                        Status(player);
                        return;
                    case "I":
                    case "i":
                        Console.Clear();
                        Inventory(player);
                        return;
                    case "B":
                    case "b":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        if (int.TryParse(input, out itemIndex) && itemIndex <= shop.items.Length && itemIndex > 0)
                        {
                            itemIndex--;
                            if (!shop.items[itemIndex].IsBuy)
                                shop.items[itemIndex].Buy(player);
                            else
                                shop.items[itemIndex].Sell(player);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!!!잘못된 입력입니다!!!");
                            Console.ResetColor();
                        }
                        break;
                }                
            }
        }
    }
}
