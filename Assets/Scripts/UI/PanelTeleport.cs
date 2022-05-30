using UnityEngine;
using UnityEngine.UI;

public class PanelTeleport : MonoBehaviour
{
    [SerializeField] private Text textNameLevel;
    private byte numberLevel;
    [SerializeField] private GameObject panel;
    private void Awake()
    {
        EventManager.ChangeSceneEvent += LoockPanelTeleport;
    }
    private void LoockPanelTeleport(string nameLevel, byte numberScene)
    {
        if (nameLevel != null)
        {
            panel.SetActive(true);
            numberLevel = numberScene;
            textNameLevel.text = "Хотите перейти в " + nameLevel + "?";
        }
        else
            panel.SetActive(false);
    }
    public void Teleport()
    {
        EventManager.LoadGameScene(numberLevel);
    }
    private void OnDestroy()
    {
        EventManager.ChangeSceneEvent -= LoockPanelTeleport;
    }
}
