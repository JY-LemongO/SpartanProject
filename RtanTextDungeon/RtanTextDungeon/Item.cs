using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanTextDungeon
{
    internal class Item
    {
        public string   Name            { get; protected set; }
        public string   AdditionalValue { get; protected set; }
        public string   AbilityName     { get; }
        public string   Desc            { get; }        
        public int      Price           { get; }
        public bool     IsEquip         { get; protected set; } = false;
        public bool     IsBuy           { get; protected set; } = false;

        public Item(string name, string abilityName, string desc, int price)
        {
            Name = name;
            AbilityName = abilityName;
            Desc = desc;
            Price = price;
        }

        public void Buy(Player player)
        {
            if (player.Gold - Price < 0)
                return;

            IsBuy = true;
            player.items.Add(this);
            player.BuyOrSell(-Price);
        }

        public void Sell(Player player)
        {            
            IsBuy = false;
            if (IsEquip)
                player.EquipOrUnequipItem(this);
            player.items.Remove(this);
            player.BuyOrSell((int)(Price * 0.85f));
        }

        public virtual void EquipItem(Player player) 
        {
            Name = "[E]" + Name;
            IsEquip = true;
        }
        public virtual void UnequipItem(Player player) 
        {
            string subString = "[E]";
            IsEquip = false;
            int index = Name.IndexOf(subString);
            Name = Name.Remove(index, subString.Length);
        }          
    }

    class Weapon : Item
    {
        public int damage;

        public override void EquipItem(Player player)
        {
            player.Atk += damage;
            AdditionalValue = $"(+{damage})";
            base.EquipItem(player);
        } 
        public override void UnequipItem(Player player)
        {
            player.Atk -= damage;
            AdditionalValue = $"";
            base.UnequipItem(player);
        }

        public Weapon(string name, string desc, int price, int damage) : base(name, "공격력", desc, price)
        {           
            this.damage = damage;
        }
    }

    class Armor : Item
    {
        public int defense;
        public override void EquipItem(Player player)
        {
            player.Def += defense;
            AdditionalValue = $"(+{defense})";
            base.EquipItem(player);
        }
        public override void UnequipItem(Player player)
        {
            player.Def -= defense;
            AdditionalValue = $"";
            base.UnequipItem(player);
        }

        public Armor(string name, string desc, int price, int defense) : base(name, "방어력", desc, price)
        {
            this.defense = defense;
        }
    }
}
