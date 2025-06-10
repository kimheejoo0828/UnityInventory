using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI critText;

    public void InitUI(Character character)
    {
        attackText.text = $"{character.Attack}";
        defenseText.text = $"{character.Defense}";
        hpText.text = $" {character.MaxHP}";
        critText.text = $"{character.Critical}";
    }

    public void OnClickBack()
    {
        UIManager.Instance.ShowMainMenu();
    }

    public void ShowUI() => gameObject.SetActive(true);
    public void HideUI() => gameObject.SetActive(false);
}
