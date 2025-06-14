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
        Sprite swordIcon = Resources.Load<Sprite>("Icons/sword");  //Resources폴더에Icons폴던안에 sword이름의 스프라이트를 로드
        Sprite shieldIcon = Resources.Load<Sprite>("Icons/shield");
        Sprite axeIcon = Resources.Load<Sprite>("Icons/axe");
        Sprite ironshieldIcon = Resources.Load<Sprite>("Icons/ironshield");
        Sprite knifeIcon = Resources.Load<Sprite>("Icons/knife");
        Sprite woodenswordIcon = Resources.Load<Sprite>("Icons/woodensword");
        Sprite spearIcon = Resources.Load<Sprite>("Icons/spear");

        var sword = new Item("단검", "기본적인 검입니다.", swordIcon, ItemType.Weapon, attack: 5); //아이템 설명및 아이템 스탯
        var shield = new Item("기본방패", "기본 방어구입니다.", shieldIcon, ItemType.Armor, defense: 3);
        var axe = new Item("도끼", "기본적인 도끼입니다.", axeIcon, ItemType.Weapon, attack: 7);
        var ironshield = new Item("철방패", "철로 만든 방패입니다.", ironshieldIcon, ItemType.Armor, defense: 8, hp: 5);
        var knife = new Item("철걸", "철로 만든 검입니다.", knifeIcon, ItemType.Weapon, attack: 7, critical: 3);
        var woodensword = new Item("나무목검", "나무로 만든 목검입니다.", woodenswordIcon, ItemType.Weapon, attack: 3);
        var spear = new Item("창", "스태프같지만 창입니다.", spearIcon, ItemType.Weapon, attack: 6);

        var inventory = new List<Item> { sword, shield, axe, ironshield, knife, woodensword, spear}; // 만든 아이템들을 리스트에 담아 캐릭터의 인벤토리로 사용

        Player = new Character("Chad", 5, 10, 5, 100, 10, 2000, inventory);

        UIManager.Instance.MainMenu.InitUI(Player);
        UIManager.Instance.Status.InitUI(Player);
        UIManager.Instance.Inventory.InitUI(Player);

        UIManager.Instance.ShowMainMenu();
    }
}
