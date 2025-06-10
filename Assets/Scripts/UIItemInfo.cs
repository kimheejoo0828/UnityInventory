using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI critText;
    [SerializeField] private GameObject panelObject; // 전체 패널을 켜고 끄기 위함

    public void SetInfo(Item item)
    {
        nameText.text = item.Name;
        descriptionText.text = item.Description;
        attackText.text = $"공격력: {item.Attack}";
        defenseText.text = $"방어력: {item.Defense}";
        hpText.text = $"체력: {item.HP}";
        critText.text = $"치명타: {item.Critical}";

        Show();
    }

    public void Show()
    {
        if (panelObject != null)
            panelObject.SetActive(true);
    }

    public void Hide()
    {
        if (panelObject != null)
            panelObject.SetActive(false);
    }

    public void OnClickClose()
    {
        Hide();
    }
}
