using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character Player { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        SetData();
    }

    private void SetData()
    {
        Sprite swordIcon = Resources.Load<Sprite>("Icons/sword");
        Sprite shieldIcon = Resources.Load<Sprite>("Icons/shield");
        Sprite axeIcon = Resources.Load<Sprite>("Icons/axe");
        Sprite ironshieldIcon = Resources.Load<Sprite>("Icons/ironshield");

        var sword = new Item("철검", "기본적인 검입니다.", swordIcon, ItemType.Weapon, attack: 5);
        var shield = new Item("기본방패", "기본 방어구입니다.", shieldIcon, ItemType.Armor, defense: 3);
        var axe = new Item("도끼", "기본적인 도끼입니다.", axeIcon, ItemType.Weapon, attack: 7);
        var ironshield = new Item("철방패", "철로 만든 방패입니다.", ironshieldIcon, ItemType.Armor, defense: 8);

        var inventory = new List<Item> { sword, shield, axe, ironshield };

        Player = new Character("Chad", 5, 10, 5, 100, 10, 2000, inventory);

        UIManager.Instance.MainMenu.InitUI(Player);
        UIManager.Instance.Status.InitUI(Player);
        UIManager.Instance.Inventory.InitUI(Player);

        UIManager.Instance.ShowMainMenu();
    }
}
