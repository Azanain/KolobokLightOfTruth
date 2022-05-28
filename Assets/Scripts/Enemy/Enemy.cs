using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int reward;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            EventManager.AddCurrentMoney(reward);
            EventManager.ChangeNumberEnemy(-1);
            Destroy(gameObject);
        }
    }
}
