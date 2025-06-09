using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtAttack;
    [SerializeField] private TextMeshProUGUI txtDefense;
    [SerializeField] private TextMeshProUGUI txtCritical;
    [SerializeField] private TextMeshProUGUI txtHp;
    [SerializeField] private Button btnBack;

    public void InitUI(Character character)
    {
        txtAttack.text = character.Attack.ToString();
        txtDefense.text = character.Defense.ToString();
        txtCritical.text = character.Critical.ToString();
        txtHp.text = character.Hp.ToString();
    }

    private void Start()
    {
        btnBack.onClick.AddListener(() => UIManager.Instance.ShowMainMenu());
    }
}
