using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Button equipButton;

    private List<UISlot> slotList = new List<UISlot>();
    private Item selectedItem;

    public void InitUI(Character character)
    {
        RefreshInventory(character.Inventory);
        selectedItem = null;

        equipButton.onClick.RemoveAllListeners();
        equipButton.onClick.AddListener(OnClickEquip);
    }

    public void RefreshInventory(List<Item> inventory)
    {
        // 기존 슬롯 제거
        foreach (var slot in slotList)
        {
            Destroy(slot.gameObject);
        }
        slotList.Clear();

        // 새로 생성
        foreach (var item in inventory)
        {
            GameObject go = Instantiate(slotPrefab, slotParent);
            UISlot slot = go.GetComponent<UISlot>();
            slot.SetItem(item);
            slot.SetClickCallback(OnItemSelected);
            slotList.Add(slot);
        }
    }

    private void OnItemSelected(Item item)
    {
        selectedItem = item;
    }

    private void OnClickEquip()
    {
        if (selectedItem != null)
        {
            GameManager.Instance.Player.EquipItem(selectedItem);
            UIManager.Instance.Status.InitUI(GameManager.Instance.Player); // 업데이트된 스탯 표시
        }
    }

    public void OnClickBack()
    {
        UIManager.Instance.ShowMainMenu();
    }
}
