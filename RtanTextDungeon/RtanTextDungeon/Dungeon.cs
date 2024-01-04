﻿using System;
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

        #region 게임시작
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

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("※※※스파르타 던전에 온 것을 환영합니다.※※※\n\n");
                Console.ResetColor();

                Console.WriteLine("-------------------------------------------\n");
                Console.WriteLine("(E) : [상태]\n\n(I) : [인벤토리]\n\n(S) : [상점]\n\n(D) : [던전입장]\n\n(R) : [휴식]\n\n(X) : [게임종료]\n");
                Console.WriteLine("-------------------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();

                string input = Console.ReadLine();
                switch (input)
                {
                    case "E":
                    case "e":
                        Console.Clear();
                        Status(player);
                        break;
                    case "I":
                    case "i":
                        Console.Clear();
                        Inventory(player);
                        break;
                    case "S":
                    case "s":
                        Console.Clear();
                        Shop(player);
                        break;
                    case "D":
                    case "d":
                        Console.Clear();
                        DungeonEntrance(player);
                        break;
                    case "R":
                    case "r":
                        Console.Clear();
                        Rest(player);
                        break;
                    case "X":
                    case "x":
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
        #endregion

        #region 상태창
        private void Status(Player player)
        {
            string weaponStatus = player.equippedItems.ContainsKey(typeof(Weapon)) ? player.equippedItems[typeof(Weapon)].AdditionalATK : "";
            string armorStatus = player.equippedItems.ContainsKey(typeof(Armor)) ? player.equippedItems[typeof(Armor)].AdditionalDEF : "";

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
                Console.WriteLine($"Lv. {player.Lv.ToString("00")}\n" +
                                $"이름\t:  {player.Name}({player.m_Class})\n\n" +
                                $"공격력\t:  {player.Atk} {weaponStatus}\n" +
                                $"방어력\t:  {player.Def} {armorStatus}\n" +
                                $"체 력\t:  {player.Hp}\n" +
                                $"Gold\t:  {player.Gold:N0} G\n");
                Console.WriteLine("-------------------------------------------\n");

                Console.WriteLine("(I) : [인벤토리]\n\n(S) : [상점]\n\n(B) : [마을로 돌아가기]\n\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();

                string input = Console.ReadLine();
                switch (input)
                {
                    case "I":
                    case "i":
                        Console.Clear();
                        Inventory(player);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!!!잘못된 입력입니다!!!");
                        Console.ResetColor();
                        break;
                }
            }
        }
        #endregion

        #region 인벤토리
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
                if (player.items.Count == 0)
                    Console.WriteLine($"[비어있음]");
                foreach (Item item in player.items)
                {
                    if (item.IsEquip)
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

                Console.WriteLine("(E) : [상태]\n\n(S) : [상점]\n\n(B) : [마을로 돌아가기]\n\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();

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
        #endregion

        #region 상점
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.Gold:N0} G\n");
                Console.ResetColor();

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

                Console.WriteLine("---------------------------------\n");

                Console.WriteLine("(E) : [상태]\n\n(I) : [인벤토리]\n\n(B) : [마을로 돌아가기]\n\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();

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
                                shop.Buy(player, shop.items[itemIndex]);
                            else
                                shop.Sell(player, shop.items[itemIndex]);
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
        #endregion

        #region 던전입구
        private void DungeonEntrance(Player player)
        {
            bool status = false;

            while (true)
            {
                Console.WriteLine(" _____                                            ");
                Console.WriteLine("|     \\ .--.--..-----..-----..-----..-----..-----.");
                Console.WriteLine("|  --  ||  |  ||     ||  _  ||  -__||  _  ||     |");
                Console.WriteLine("|_____/ |_____||__|__||___  ||_____||_____||__|__|");
                Console.WriteLine("                      |_____|                     ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("====================[던전 입구]====================");
                Console.ResetColor();
                Console.WriteLine("---------------------------------\n");

                Console.WriteLine("=================================\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (!status)
                    Console.WriteLine("(E) : ▶ 내 정보\n");
                else
                {
                    Console.WriteLine("(E) : ▼ 내 정보");
                    Console.WriteLine($"{player.Name} Lv. {player.Lv.ToString("00")}\n\n" +
                                $"공격력\t:  {player.Atk}\n" +
                                $"방어력\t:  {player.Def}\n" +
                                $"체 력\t:  {player.Hp}\n" +
                                $"Gold\t:  {player.Gold:N0} G\n");
                }
                Console.ResetColor();
                Console.WriteLine("=================================\n");

                Console.WriteLine("난이도를 선택하세요.\n");
                Console.WriteLine("(1) : [쉬움]\t| 방어력 [10] 이상 권장 \n" +
                    "(2) : [보통]\t| 방어력 [25] 이상 권장\n" +
                    "(3) : [어려움]\t| 방어력 [70] 이상 권장\n\n" +
                    "(B) : [마을로 돌아가기]\n");

                Console.WriteLine("---------------------------------");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        EnterDungeon(player, Define.DungeonDiff.Easy);
                        break;
                    case "2":
                        Console.Clear();
                        EnterDungeon(player, Define.DungeonDiff.Normal);
                        break;
                    case "3":
                        Console.Clear();
                        EnterDungeon(player, Define.DungeonDiff.Hard);
                        break;
                    case "E":
                    case "e":
                        Console.Clear();
                        status = !status;
                        break;
                    case "B":
                    case "b":
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
        #endregion

        #region 던전
        private void EnterDungeon(Player player, Define.DungeonDiff diff)
        {
            Console.WriteLine(" _____                                            ");
            Console.WriteLine("|     \\ .--.--..-----..-----..-----..-----..-----.");
            Console.WriteLine("|  --  ||  |  ||     ||  _  ||  -__||  _  ||     |");
            Console.WriteLine("|_____/ |_____||__|__||___  ||_____||_____||__|__|");
            Console.WriteLine("                      |_____|                     \n\n");

            int[] recommendDEF = [ 10, 25, 70 ];
            int[] rewards = [ 500, 1500, 2500 ];
            int[] exp = [300, 15, 50];
            string[] difficulties = { "쉬움", "보통", "어려움" };

            int randomDamage = new Random().Next(20, 36);
            float randomAdditionalGold = 1 + new Random().Next(player.Atk, player.Atk * 2 + 1) * 0.01f;

            int getDamage = (randomDamage + (recommendDEF[(int)diff] - player.Def)) < 0 ? 0 : (randomDamage + (recommendDEF[(int)diff] - player.Def));
            int getGold = (int)(rewards[(int)diff] * randomAdditionalGold);
            int getEXP = exp[(int)diff];
            int fail = new Random().Next(0, 10);

            Console.WriteLine("-------------------------------------------\n");
            if (player.Def < recommendDEF[(int)diff] && fail < 4)
            {
                // 실패 시 보상x 받는 데미지 절반
                player.GetDamage(getDamage / 2);
                Console.WriteLine("던전 클리어에 실패했습니다!\n");
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 : {player.MaxHp} -> {player.Hp}\n");
            }
            else
            {
                int prevGold = player.Gold;
                player.GetDamage(getDamage);
                player.GetGold(getGold);                
                Console.WriteLine("축하합니다!");
                Console.WriteLine($"[{difficulties[(int)diff]}] 던전을 클리어 했습니다!\n");
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 : {player.MaxHp} -> {player.Hp}");                
                Console.WriteLine($"Gold : {prevGold} -> {player.Gold}\n");
                Console.WriteLine($"경험치를 {getEXP} 획득했습니다.\n");

                int lv = player.Lv;
                if (player.IsLevelUp(getEXP))
                    Console.WriteLine($"LevelUp!  Lv. {lv:00} -> {player.Lv:00}\n");
            }
            Console.WriteLine("-------------------------------------------\n");

            Console.WriteLine("(B) : [나가기]\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
            Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
            Console.ResetColor();

            string input = Console.ReadLine();
            switch (input)
            {
                case "B":
                case "b":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!!잘못된 입력입니다!!!");
                    Console.ResetColor();
                    break;
            }
        }
        #endregion

        #region 휴식
        private void Rest(Player player)
        {
            bool rest = false;
            bool fullCondition = player.Hp == player.MaxHp;
            while (true)
            {
                Console.WriteLine(" __               ");
                Console.WriteLine("|__|.-----..-----.");
                Console.WriteLine("|  ||     ||     |");
                Console.WriteLine("|__||__|__||__|__|");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==================[여 관]==================");
                Console.ResetColor();
                Console.WriteLine("-------------------------------------------\n");

                Console.WriteLine($"500 G 를 지불하시면 체력을 회복할 수 있습니다. (보유골드 : {player.Gold} G)\n");
                if (rest)
                {
                    if (fullCondition)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"이미 컨디션이 최상입니다!\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"회복되었습니다!\n");
                        Console.ResetColor();
                        fullCondition = true;
                    }
                }

                Console.WriteLine("(R) : [휴식]\n\n(B) : [마을로 돌아가기]\n");

                Console.WriteLine("-------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("※※※원하시는 행동을 선택하세요.※※※");
                Console.WriteLine("※※※입력값은 대소문자를 구분하지 않습니다.※※※\n");
                Console.ResetColor();

                string input = Console.ReadLine();
                switch (input)
                {
                    case "R":
                    case "r":
                        Console.Clear();
                        rest = true;
                        if (!fullCondition)
                        {
                            player.Rest();
                            player.GetGold(-500);
                        }
                        break;
                    case "B":
                    case "b":
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
        #endregion
    }
}
