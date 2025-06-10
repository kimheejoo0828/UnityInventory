using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject equipMarkObject;

    private Item item;
    private System.Action<Item> onClickCallback;

    public void SetItem(Item newItem, bool isEquipped = false)
    {
        item = newItem;
        iconImage.sprite = item.Icon;
        nameText.text = item.Name;

        equipMarkObject?.SetActive(isEquipped); // 장착 여부 표시
    }

    public void SetClickCallback(System.Action<Item> callback)
    {
        onClickCallback = callback;
    }

    public void OnClickSlot()
    {
            onClickCallback?.Invoke(item);
    }
}
