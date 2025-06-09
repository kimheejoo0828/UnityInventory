using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform slotParent; // ���� slot prefab�� ���� ����
    [SerializeField] private Button btnBack;

    private void Start()
    {
        btnBack.onClick.AddListener(() => UIManager.Instance.ShowMainMenu());
    }

    public void InitUI(Character character)
    {
        // ���߿� character.Inventory �����͸� �޾� ���� ����
    }
}
