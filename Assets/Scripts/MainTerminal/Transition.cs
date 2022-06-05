using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private GameObject buttonYes;
    [SerializeField] private GameObject buttonNo;
    [SerializeField] private GameObject uiMainTerminal;
    [SerializeField] private GameObject panelGoToTheMainTerminal;
    [SerializeField] private GameObject uiPlayerController;


    /// <summary>
    /// метод активации меню главного терминала
    /// </summary>
    public void ClickButtonYes()
    {
        Time.timeScale = 0f;
        panelGoToTheMainTerminal.SetActive(false);
        uiMainTerminal.SetActive(true);
    }

    /// <summary>
    /// метод закрытия главного меню
    /// </summary>
    public void CloseMainTerUI()
    {
        uiMainTerminal.SetActive(false);
        uiPlayerController.SetActive(true);
        Time.timeScale = 1f;
    }
    
     /// <summary>
     /// метод нажатияя кнопки "нет"
     /// </summary>
    public void ClickButtonNo()
    {
        panelGoToTheMainTerminal.SetActive(false);
    }
}
