using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character : MonoBehaviour
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int MaxHP { get; private set; }
    public int Critical { get; private set; }
    public int Gold { get; private set; }

    public List<Item> Inventory { get; private set; }

    public Character(string name, int level, int attack, int defense, int maxHP, int critical, int gold = 0, List<Item> inventory = null)
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
}
