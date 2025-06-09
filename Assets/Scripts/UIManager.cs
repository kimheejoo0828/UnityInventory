using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    public UIMainMenu MainMenu => uiMainMenu;
    public UIStatus Status => uiStatus;
    public UIInventory Inventory => uiInventory;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void ShowMainMenu()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(false);
    }

    public void ShowStatus()
    {
        uiMainMenu.gameObject.SetActive(false);
        uiStatus.gameObject.SetActive(true);
        uiInventory.gameObject.SetActive(false);
    }

    public void ShowInventory()
    {
        uiMainMenu.gameObject.SetActive(false);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(true);
    }
}
