using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanTextDungeon
{
    internal class Player
    {
        public int Lv                       { get; private set; }
        public string Name                  { get; private set; }
        public Define.PlayerClass m_Class   { get; private set; }
        public int Atk                      { get; set; }
        public int Def                      { get; set; }
        public int Hp                       { get; private set; }
        public int MaxHp                    { get; private set; }
        public int Gold                     { get; private set; }
        public int EXP                      { get; private set; }

        public Dictionary<Type, Item> equippedItems = new Dictionary<Type, Item>();
        public List<Item> items = new List<Item>();

        private int needEXP = 10;

        public Player(Define.PlayerClass playerClass)
        {
            Lv = 1;
            Name = "르탄이";
            m_Class = playerClass;
            Atk = 10;
            Def = 5;
            Hp = 100;
            MaxHp = 100;
            Gold = 1500;
        }

        public void BuyOrSell(int price) => Gold += price;

        public void EquipOrUnequipItem(Item item)
        {
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

        public void GetGold(int gold) => Gold += gold;

        public void Rest() => Hp = MaxHp;

        public void GetDamage(int damage)
        {
            Hp -= damage;
            if(Hp < 0)
                Hp = 0;
        }        

        public bool IsLevelUp(int exp)
        {
            EXP += exp;
            if(EXP >= needEXP)
            {
                LevelUp();
                int remainExp = EXP - needEXP;
                needEXP *= 2;
                EXP = 0;
                IsLevelUp(remainExp);
                return true;
            }
            return false;
        }

        private void LevelUp()
        {
            Lv++;
            Atk += 3;
            Def += 1;            
        }
    }
}
