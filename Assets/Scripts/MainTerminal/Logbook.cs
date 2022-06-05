using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logbook : MonoBehaviour
{
    [SerializeField] private GameObject uiMainTerminal;
    [SerializeField] private GameObject uiLogbook;
    [SerializeField] private GameObject uiPlayerController;

    /// <summary>
    /// ����� ��������� ������ ��������� �������
    /// </summary>
    public void ActivePanelLogbok()
    {
        uiPlayerController.SetActive(false);
        uiMainTerminal.SetActive(false);
        uiLogbook.SetActive(true);
    }
    /// <summary>
    /// ������ �����
    /// </summary>
    public void ButtonBack()
    {
        uiLogbook.SetActive(false);
        uiMainTerminal.SetActive(true);   
    }
}
