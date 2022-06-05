using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Album : MonoBehaviour
{
    [SerializeField] private GameObject uiMainTerminal;
    [SerializeField] private GameObject uiPlayerController;
    [SerializeField] private GameObject uiAlbum;

    /// <summary>
    /// метод активации панеля 
    /// </summary>
    public void ActivePanelAlbum()
    {
        uiPlayerController.SetActive(false);
        uiMainTerminal.SetActive(false);
        uiAlbum.SetActive(true);
    }

    /// <summary>
    /// кнопка назад
    /// </summary>
    public void ButtonBack()
    {
        uiAlbum.SetActive(false);
        uiMainTerminal.SetActive(true);
    }
}
