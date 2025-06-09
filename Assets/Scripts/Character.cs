using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }

    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Critical { get; private set; }
    public int Hp { get; private set; }

    public Character(string name, int level, int gold, int atk, int def, int crit, int hp)
    {
        Name = name;
        Level = level;
        Gold = gold;
        Attack = atk;
        Defense = def;
        Critical = crit;
        Hp = hp;
    }
}
