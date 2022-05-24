using UnityEngine;

public class Player : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        EventManager.TakeDamage(damage);
    }
}
