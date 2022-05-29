using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int reward;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(gameObject.ToString() + "HP=" + hp);
        if (hp <= 0)
        {
            Debug.Log("Rabbit killed");
            EventManager.AddCurrentMoney(reward);
            EventManager.ChangeNumberEnemy(-1);
            Destroy(gameObject);
        }
    }
}
