using UnityEngine;

public class ChangeSceneCabine : MonoBehaviour
{
    [SerializeField] private byte numberScene;
    [SerializeField] private string nameChosenScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.ChangeScene(nameChosenScene, numberScene);
        }
    }
    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Player"))
       {
            EventManager.ChangeScene(null, numberScene);
       }
    }
}
