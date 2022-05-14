using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    [SerializeField] private int idStage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EventManager.LoadGameScene(idStage);
        }
    }
}
