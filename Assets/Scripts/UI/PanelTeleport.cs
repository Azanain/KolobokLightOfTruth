using UnityEngine;
using UnityEngine.UI;

public class PanelTeleport : MonoBehaviour
{
    [SerializeField] private Text textNameLevel;
    [SerializeField] private byte numberLevel;
    [SerializeField] private GameObject panel;
    private void Awake()
    {
        EventManager.NameChosenLevelEvent += LoockPanelTeleport;
    }
    private void LoockPanelTeleport(string nameLevel)
    {
        if (nameLevel != null)
        {
            panel.SetActive(true);
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
        EventManager.NameChosenLevelEvent -= LoockPanelTeleport;
    }
}
