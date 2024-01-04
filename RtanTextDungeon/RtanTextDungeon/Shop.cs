using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RtanTextDungeon
{
    internal class Shop
    {
        public Item[] items =
        {
            new Weapon(0, "[낡은 검]", "쉽게 부러질 것 같은 검입니다.", 150, 5),
            new Weapon(1, "[롱 소드]", "보편적으로 사용되는 검입니다.", 500, 15),
            new Weapon(2, "[양손 대검]", "나무를 벨 때 사용되던 도끼입니다.", 500, 30),
            new Weapon(3, "[반월 검]", "반월의 형상을 가진 어둠속에서 빛나는 검입니다.", 1500, 50),
            new Weapon(4, "[암흑 낫]", "영혼을 거두어 간다고 알려진 낫입니다.", 5000, 100),
            new Weapon(5, "[스파르타의 창]", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 10000, 150),

            new Armor(6, "[천 옷]", "흔해빠진 옷입니다.", 200, 10),
            new Armor(7, "[가죽 갑옷]", "일반 병사들이 입는 갑옷입니다.", 400, 25),
            new Armor(8, "[판금 갑옷]", " 판금으로 만들어진 튼튼한 갑옷입니다..", 1200, 45),
            new Armor(9, "[미스릴 갑옷]", "미스릴로 만들어진 희귀한 갑옷입니다.", 3000, 80),
            new Armor(10, "[용기사의 갑옷]", "용기사들이 사용하는 용의 비늘로 만들어진 갑옷입니다..", 7500, 130),
            new Armor(11, "[스파르타의 갑옷]", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15000, 200),
        };

        public void Buy(Player player, Item item)
        {
            if (player.Gold - item.Price < 0)
                return;

            item.GetItem();
            player.BuyOrSell(-item.Price, item);
        }

        public void Sell(Player player, Item item)
        {
            item.RemoveItem();
            player.BuyOrSell((int)(item.Price * 0.85f), item, true);
        }

        public void Restore(Player player, Item item)
        {
            item.GetItem();
            player.BuyOrSell(0, item);
        }
    }
}
