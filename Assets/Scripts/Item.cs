using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor
}

public class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Sprite Icon { get; private set; }

    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int HP { get; private set; }
    public int Critical { get; private set; }

    public ItemType Type { get; private set; }

    public Item(string name, string description, Sprite icon, ItemType type, int attack = 0, int defense = 0, int hp = 0, int critical = 0)
    {
        Name = name;
        Description = description;
        Icon = icon;
        Attack = attack;
        Defense = defense;
        HP = hp;
        Critical = critical;
        Type = type;
    }
}
