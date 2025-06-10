using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int MaxHP { get; private set; }
    public int Critical { get; private set; }
    public int Gold { get; private set; }

    public List<Item> Inventory { get; private set; }

    private Item equippedWeapon;
    private Item equippedArmor;

    public Item EquippedWeapon => equippedWeapon;
    public Item EquippedArmor => equippedArmor;

    private Item equippedItem = null;
    public Item EquippedItem => equippedItem;

    public Character(string name, int level, int attack, int defense, int maxHP, int critical, int gold, List<Item> inventory)
    {
        Name = name;
        Level = level;
        Attack = attack;
        Defense = defense;
        MaxHP = maxHP;
        Critical = critical;
        Gold = gold;
        Inventory = inventory ?? new List<Item>();
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void EquipItem(Item item)
    {
        if (!Inventory.Contains(item))
            return;

        switch (item.Type)
        {
            case ItemType.Weapon:
                if (equippedWeapon != null)
                    UnEquipItem(equippedWeapon);
                equippedWeapon = item;
                break;

            case ItemType.Armor:
                if (equippedArmor != null)
                    UnEquipItem(equippedArmor);
                equippedArmor = item;
                break;
        }

        Attack += item.Attack;
        Defense += item.Defense;
        MaxHP += item.HP;
        Critical += item.Critical;
    }

    public void UnEquipItem(Item item)
    {
        if (item == null) return;

        Attack -= item.Attack;
        Defense -= item.Defense;
        MaxHP -= item.HP;
        Critical -= item.Critical;

        if (equippedWeapon == item)
            equippedWeapon = null;
        else if (equippedArmor == item)
            equippedArmor = null;
    }

    public bool IsEquipped(Item item)
    {
        return item == equippedWeapon || item == equippedArmor;
    }
}
