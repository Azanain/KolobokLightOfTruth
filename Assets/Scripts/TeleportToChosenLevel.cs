using UnityEngine;

public class TeleportToChosenLevel : MonoBehaviour
{
    [SerializeField] private string nameLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            EventManager.NameChosenLevel(nameLevel);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            EventManager.NameChosenLevel(null);
    }
}
