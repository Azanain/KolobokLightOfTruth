using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int reward;
    private Gob01Follow gob;
    public bool IsDead { get; private set; }
    private void Awake()
    {
        gob = GetComponent<Gob01Follow>();
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            IsDead = true;
            gob.StartAnimationDeath();
            EventManager.AddCurrentMoney(reward);
            //EventManager.ChangeNumberEnemy(-1);
           
        }
    }
}
