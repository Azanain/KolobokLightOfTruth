using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private GameObject buttonYes;
    [SerializeField] private GameObject buttonNo;
    [SerializeField] private GameObject uiMainTerminal;
    [SerializeField] private GameObject panelGoToTheMainTerminal;

    /// <summary>
    /// ����� ��������� ���� �������� ���������
    /// </summary>
    public void ClickButtonYes()
    {
        Time.timeScale = 0f;
        panelGoToTheMainTerminal.SetActive(false);
        uiMainTerminal.SetActive(true);
    }

    /// <summary>
    /// ����� �������� �������� ����
    /// </summary>
    public void CloseMainTerUI()
    {
        uiMainTerminal.SetActive(false);
        Time.timeScale = 1f;
    }
    
     /// <summary>
     /// ����� �������� ������ "���"
     /// </summary>
    public void ClickButtonNo()
    {
        panelGoToTheMainTerminal.SetActive(false);
    }
}
