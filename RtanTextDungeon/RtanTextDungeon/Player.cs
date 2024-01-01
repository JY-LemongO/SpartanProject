using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanTextDungeon
{
    internal class Player
    {
        public int lv;
        public string name;
        public Define.PlayerClass m_class;
        public int atk;
        public int def;
        public int hp;
        public int maxHp;
        public int gold;
        
        public Dictionary<Type, Item> equippedItems = new Dictionary<Type, Item>();
        public List<Item> items = new List<Item>();

        public Player(Define.PlayerClass playerClass)
        {
            lv = 1;
            name = "르탄이";
            m_class = playerClass;
            atk = 10;
            def = 5;
            hp = 100;
            maxHp = 100;
            gold = 1500;
        }

        public void BuyOrSell(int price) => gold += price;

        public void EquipOrUnequipItem(Item item)
        {
            Console.WriteLine("뭔가 장착,장착해제 했음");

            // item의 Type이(Weapon or Armor) 이미 있을 때 = 뭔가 장착 중일 때
            if (equippedItems.ContainsKey(item.GetType()))
            {
                // 동일 아이템이면
                // 단순 장착해제
                if (equippedItems[item.GetType()].Name == item.Name)
                    UnequipItem(item);
                // 동일 아이템이 아니면
                // 현재 아이템 장착해제 후 선택한 아이템 장착
                else
                {
                    UnequipItem(equippedItems[item.GetType()]);
                    EquipItem(item);
                }
            }
            // 장착중인 아이템이 없을 때
            else
                EquipItem(item);
        }

        private void EquipItem(Item item)
        {
            item.EquipItem(this);
            equippedItems[item.GetType()] = item;
        }

        private void UnequipItem(Item item)
        {
            Item equippedItem = equippedItems[item.GetType()];
            equippedItem.UnequipItem(this);
            equippedItems.Remove(item.GetType());
        }
    }
}
