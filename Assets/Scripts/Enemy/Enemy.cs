using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"урон по врагу {damage}");
        if (hp <= 0)
        {
            Debug.Log("enemy death");
            Destroy(gameObject);
        }
    }
}
