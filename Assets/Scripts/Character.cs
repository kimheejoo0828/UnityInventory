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
        if (!Inventory.Contains(item)) //인벤토리에 아이템이 없다면 장착취소
            return;

        switch (item.Type)
        {
            case ItemType.Weapon:  //아이템이 무기일 경우
                if (equippedWeapon != null) //기존 무기가 있다면 먼저해제
                    UnEquipItem(equippedWeapon);
                equippedWeapon = item; //새로운 아이템을 무기로 장착
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
        return item == equippedWeapon || item == equippedArmor; //아이템이 현재 무기 또는 방어구 슬롯에 장착된 상태인지 여부를 반환
    }
}
