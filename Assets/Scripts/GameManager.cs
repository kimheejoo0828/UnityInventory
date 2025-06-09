using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Character player;
    public Character Player => player;

    private void Start()
    {
        SetData();
    }

    private void SetData()
    {
        player = new Character("Chad", 10, 2000, 10, 10, 10, 10);

        UIManager.Instance.MainMenu.InitUI(player);
        UIManager.Instance.Status.InitUI(player);
        UIManager.Instance.Inventory.InitUI(player);
        UIManager.Instance.ShowMainMenu();
    }
}
