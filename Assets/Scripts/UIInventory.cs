using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform slotParent; // 추후 slot prefab과 연결 예정
    [SerializeField] private Button btnBack;

    private void Start()
    {
        btnBack.onClick.AddListener(() => UIManager.Instance.ShowMainMenu());
    }

    public void InitUI(Character character)
    {
        // 나중에 character.Inventory 데이터를 받아 슬롯 생성
    }
}
