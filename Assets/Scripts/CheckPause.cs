using UnityEngine;

public class CheckPause : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    private void Awake()
    {
        EventManager.PauseEvent += Pause;
        menuPause.SetActive(false);
    }
    private void Pause()
    {
        menuPause.SetActive(true);
    }
    private void OnDestroy()
    {
        EventManager.PauseEvent -= Pause;
    }
}
