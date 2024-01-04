using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static RtanTextDungeon.Define;

namespace RtanTextDungeon
{    
    internal class Player
    {
        public int Lv                       { get; private set; }
        public string Name                  { get; private set; }        
        public PlayerClass m_Class          { get; private set; }
        public int Atk                      { get; set; }
        public int Def                      { get; set; }
        public int Hp                       { get; private set; }
        public int MaxHp                    { get; private set; }
        public int Gold                     { get; private set; }
        public int EXP                      { get; private set; }        

        // 런타임에서 가지고 있을 아이템 정보들
        public Dictionary<Type, Item>   equippedItems       = new Dictionary<Type, Item>();        
        public List<Item>               items               = new List<Item>();

        // 저장시 가지고 있을 아이템 ID
        public Dictionary<string, int>  equippedItemIndex   = new Dictionary<string, int>();
        public List<int>                hasItems            = new List<int>();

        private int needEXP = 10;

        public Player(int Lv, string Name, PlayerClass m_Class, int Atk, int Def, int Hp, int MaxHp, int Gold)
        {
            this.Lv = Lv;
            this.Name = Name;
            this.m_Class = m_Class;
            this.Atk = Atk;
            this.Def = Def;
            this.Hp = Hp;
            this.MaxHp = MaxHp;
            this.Gold = Gold;
        }

        public void RemoveItemAbilityBeforeSave()
        {
            if (equippedItems.TryGetValue(typeof(Weapon), out var weapon))
            {
                Weapon equippedWeapon = (Weapon)weapon;
                Atk -= equippedWeapon.damage;
            }
            if (equippedItems.TryGetValue(typeof(Armor), out var armor))
            {
                Armor equippedArmor = (Armor)armor;
                Def -= equippedArmor.defense;
            }
        }

        public void BuyOrSell(int price, Item item, bool isSell = false)
        {
            Gold += price;
            if (!isSell)
            {
                // 불러오기 시 hasItems에 포함된 ID인지 체크없이 Add 하게되면 무한루프에 빠지게된다.
                if (!hasItems.Contains(item.ID))
                    hasItems.Add(item.ID);
                items.Add(item);
            }
            else
            {
                hasItems.Remove(item.ID);
                if (item.IsEquip)
                    EquipOrUnequipItem(item);
                items.Remove(item);
            }
        }

        public void EquipOrUnequipItem(Item item)
        {
            // item의 Type이(Weapon or Armor) 이미 있을 때 = 뭔가 장착 중일 때
            if (equippedItems.ContainsKey(item.GetType()))
            {
                // 동일 아이템이면
                // 단순 장착해제
                if (equippedItems[item.GetType()].ID == item.ID)
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
            if (item is Weapon weapon)
            {
                weapon.EquipItem();
                Atk += weapon.damage;                
            }
            else if(item is Armor armor)
            {
                armor.EquipItem();
                Def += armor.defense;
            }

            // 불러오기 시 장착중인 아이템이 저장 되어있으면 중복으로 에러발생.
            if (!equippedItemIndex.ContainsKey(item.GetType().Name))
                equippedItemIndex.Add(item.GetType().Name, item.ID);
            equippedItems[item.GetType()] = item;            
        }

        private void UnequipItem(Item item)
        {
            if (item is Weapon weapon)
            {
                weapon.UnequipItem();
                Atk -= weapon.damage;
            }
            else if (item is Armor armor)
            {
                armor.UnequipItem();
                Def -= armor.defense;
            }
            equippedItemIndex.Remove(item.GetType().Name);
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
