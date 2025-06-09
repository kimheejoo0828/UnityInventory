using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtLevel;
    [SerializeField] private TextMeshProUGUI txtGold;

    [SerializeField] private Button btnStatus;
    [SerializeField] private Button btnInventory;

    public void InitUI(Character character)
    {
        txtName.text = character.Name;
        txtLevel.text = $"{character.Level}";
        txtGold.text = character.Gold.ToString("");
    }

    private void Start()
    {
        btnStatus.onClick.AddListener(() => UIManager.Instance.ShowStatus());
        btnInventory.onClick.AddListener(() => UIManager.Instance.ShowInventory());
    }
}
