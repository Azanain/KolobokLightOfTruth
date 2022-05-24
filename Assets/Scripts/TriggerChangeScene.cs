using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    [SerializeField] private int idStage;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trig");
        if(other.CompareTag("Player"))
        {
            EventManager.LoadGameScene(idStage);
        }
    }
}
