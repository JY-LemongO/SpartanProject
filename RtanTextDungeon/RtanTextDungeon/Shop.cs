using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanTextDungeon
{
    internal class Shop
    {
        public Item[] items =
        {
            new Weapon("[낡은 검]", "쉽게 부러질 것 같은 검입니다.", 150, 5),
            new Weapon("[롱 소드]", "보편적으로 사용되는 검입니다.", 300, 15),
            new Weapon("[양손 대검]", "나무를 벨 때 사용되던 도끼입니다.", 500, 30),
            new Weapon("[반월 검]", "반월의 형상을 가진 어둠속에서 빛나는 검입니다.", 1500, 50),
            new Weapon("[암흑 낫]", "영혼을 거두어 간다고 알려진 낫입니다.", 3000, 100),
            new Weapon("[스파르타의 창]", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 5000, 150),

            new Armor("[천 옷]", "흔해빠진 옷입니다.", 200, 10),
            new Armor("[가죽 갑옷]", "일반 병사들이 입는 갑옷입니다.", 400, 25),
            new Armor("[판금 갑옷]", " 판금으로 만들어진 튼튼한 갑옷입니다..", 750, 45),
            new Armor("[미스릴 갑옷]", "미스릴로 만들어진 희귀한 갑옷입니다.", 2000, 80),
            new Armor("[용기사의 갑옷]", "용기사들이 사용하는 용의 비늘로 만들어진 갑옷입니다..", 4500, 130),
            new Armor("[스파르타의 갑옷]", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 6500, 200),
        };
    }
}
