using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logbook : MonoBehaviour
{
    [SerializeField] private GameObject uiMainTerminal;
    [SerializeField] private GameObject uiLogbook;
    [SerializeField] private GameObject uiPlayerController;

    /// <summary>
    /// метод активации панеля бортового журнала
    /// </summary>
    public void ActivePanelLogbok()
    {
        uiPlayerController.SetActive(false);
        uiMainTerminal.SetActive(false);
        uiLogbook.SetActive(true);
    }
    /// <summary>
    /// кнопка назад
    /// </summary>
    public void ButtonBack()
    {
        uiLogbook.SetActive(false);
        uiMainTerminal.SetActive(true);   
    }
}
