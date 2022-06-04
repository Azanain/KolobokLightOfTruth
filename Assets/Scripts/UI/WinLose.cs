using System.Collections;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        EventManager.WinEvent += CheckPanel;
    }
    /// <summary>
    /// проверка, какую панель показать
    /// </summary>
    /// <param name="isWin"></param>
    private void CheckPanel(bool isWin)
    {
        if (isWin)
        {
            StartCoroutine(TimerWinPanel());
        }
        else
        { 
            losePanel.SetActive(true);
            EventManager.Pause();
        }    
    }
    /// <summary>
    /// при нажатии на кнопку, перезапускает сцену
    /// </summary>
    public void ButtonTryAgain()
    {
        int numberScene = SceneTransition.NumberCurrentScene;
        EventManager.LoadGameScene(numberScene);
    }
    /// <summary>
    /// при нажатии на кнопку, возврат в хаб
    /// </summary>
    public void ButtonToHub()
    {
        EventManager.LoadGameScene(2);
    }
    private IEnumerator TimerWinPanel()
    { 
        winPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        winPanel.SetActive(false);
        EventManager.TransferMoney();
        StopCoroutine(TimerWinPanel());
    }
    private void OnDestroy()
    {
        EventManager.WinEvent -= CheckPanel;
    }
}
