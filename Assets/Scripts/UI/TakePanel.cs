using UnityEngine;

public class TakePanel : MonoBehaviour
{
    public void TakeActivePanel(GameObject panel)
    {
        if (panel.activeInHierarchy)
            panel.SetActive(false);
        else
            panel.SetActive(true);
    }

}
