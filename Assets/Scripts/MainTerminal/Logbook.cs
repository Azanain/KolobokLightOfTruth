using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logbook : MonoBehaviour
{
    [SerializeField] private GameObject uiMainTerminal;
    [SerializeField] private GameObject uiLogbook;
    [SerializeField] private GameObject uiLogbook_2;
    [SerializeField] private GameObject uiLogbook_3;
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
    public void ButtonExit()
    {
        uiLogbook.SetActive(false);
        uiMainTerminal.SetActive(true);   
    }

    /// <summary>
    /// ������ ����� �� uiLogbook
    /// </summary>
    public void ButtonBack()
    {
        uiLogbook_2.SetActive(false);
        uiLogbook.SetActive(true);
    }

    /// <summary>
    /// ������ ����� �� uiLogbook_2
    /// </summary>
    public void ButtonBack2()
    {
        uiLogbook_3.SetActive(false);
        uiLogbook_2.SetActive(true);
    }

    /// <summary>
    /// ������ ������ �� uiLogbook_2
    /// </summary>
    public void ButtonGo()
    {
        uiLogbook.SetActive(false);
        uiLogbook_2.SetActive(true);
    }

    /// <summary>
    /// ������ ������ �� uiLogbook_3
    /// </summary>
    public void ButtonGo2()
    {
        uiLogbook_2.SetActive(false);
        uiLogbook_3.SetActive(true);
    }
}
