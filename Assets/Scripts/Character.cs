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

        if (equippedItem != null)
        {
            UnEquipItem(equippedItem);
        }

        // 새 아이템 장착
        equippedItem = item;

        Attack += item.Attack;
        Defense += item.Defense;
        MaxHP += item.HP;
        Critical += item.Critical;
    }

    public void UnEquipItem(Item item)
    {
        Attack -= item.Attack;
        Defense -= item.Defense;
        MaxHP -= item.HP;
        Critical -= item.Critical;
    }

    public bool IsEquipped(Item item)
    {
        return equippedItem != null && item != null && equippedItem == item;
    }
}
