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
    [SerializeField] private GameObject panelObject; // ��ü �г��� �Ѱ� ���� ����

    public void SetInfo(Item item)
    {
        nameText.text = item.Name;
        descriptionText.text = item.Description;
        attackText.text = $"���ݷ�: {item.Attack}";
        defenseText.text = $"����: {item.Defense}";
        hpText.text = $"ü��: {item.HP}";
        critText.text = $"ġ��Ÿ: {item.Critical}";

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
