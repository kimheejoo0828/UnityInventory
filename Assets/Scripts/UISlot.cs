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
    private Item item;
    private System.Action<Item> onClickCallback;

    public void SetItem(Item newItem)
    {
        item = newItem;
        iconImage.sprite = item.Icon;
        nameText.text = item.Name;
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
