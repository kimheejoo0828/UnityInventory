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
    [SerializeField] private Button unequipButton;

    private List<UISlot> slotList = new List<UISlot>();
    private Item selectedItem;

    public void InitUI(Character character)
    {
        RefreshInventory(character.Inventory);
        selectedItem = null;

        equipButton.onClick.RemoveAllListeners(); 
        equipButton.onClick.AddListener(OnClickEquip);
        unequipButton.onClick.AddListener(OnClickUnequip);
    }

    public void RefreshInventory(List<Item> inventory)
    {
        foreach (var slot in slotList)
        {
            Destroy(slot.gameObject);
        }
        slotList.Clear();

        foreach (var item in inventory)
        {
            GameObject go = Instantiate(slotPrefab, slotParent);
            UISlot slot = go.GetComponent<UISlot>();
            bool isEquipped = GameManager.Instance.Player.IsEquipped(item); //���� ���� �Ǵ�
            slot.SetItem(item, isEquipped); //������ ������ ���� ���� ����
            slot.SetClickCallback(OnItemSelected);
            slotList.Add(slot);
        }
    }

    private void OnItemSelected(Item item)
    {
        selectedItem = item;
        UIManager.Instance.ShowItemInfo(item);
    }

    private void OnClickEquip()
    {
        if (selectedItem != null)
        {
            GameManager.Instance.Player.EquipItem(selectedItem);
            RefreshInventory(GameManager.Instance.Player.Inventory); //�κ��丮 �ٽ� �׸�
            UIManager.Instance.Status.InitUI(GameManager.Instance.Player); // ������Ʈ�� ���� ǥ��
        }
    }

    public void OnClickBack()
    {
        UIManager.Instance.ShowMainMenu();
    }

    private void OnClickUnequip()
    {
        if (selectedItem == null) return;

        GameManager.Instance.Player.UnEquipItem(selectedItem);

        // UI ����
        RefreshInventory(GameManager.Instance.Player.Inventory);
        UIManager.Instance.Status.InitUI(GameManager.Instance.Player);
    }
}
