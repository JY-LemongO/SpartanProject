using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RtanTextDungeon
{
    internal class Item
    {
        public string name;

        public virtual void EquipItem(Player player) { }
        public virtual void UnequipItem(Player player) { }        
    }

    class Weapon : Item
    {
        public int damage;

        public override void EquipItem(Player player)
        {
            player.weapon = this;
            player.atk += damage;
        } 

        public override void UnequipItem(Player player)
        {
            player.weapon = null;
            player.atk -= damage;
        }

        public Weapon(int damage, string name)
        {
            this.name = name;
            this.damage = damage;
        }
    }

    class Armor : Item
    {
        public int defense;
        public override void EquipItem(Player player)
        {
            player.armor = this;
            player.def += defense;
        }
        
        public override void UnequipItem(Player player)
        {
            player.armor = null;
            player.def -= defense;
        }        

        public Armor(int defense, string name)
        {
            this.name = name;
            this.defense = defense;
        }
    }
}
