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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChargedLaser"))
        {
            TakeDamage(ButtonRay.WeaponDamage2_2);
            Debug.Log($"charged laser hit {ButtonRay.WeaponDamage2_2}");
        }
    }
}
