using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            EventManager.ChangeNumberEnemy(-1);
            Destroy(gameObject);
        }
    }
}
