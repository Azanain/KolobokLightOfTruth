using UnityEngine;

public class WordOfPower : MonoBehaviour
{
    [SerializeField] private bool isBigWord;
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (isBigWord)
            {
                enemy.TakeDamage(PlayerParametrs.DamageWeapon3);
                Debug.Log($"урон по врагу {PlayerParametrs.DamageWeapon3}");
            }
            else
            { 
                enemy.TakeDamage(PlayerParametrs.DamageWeapon3_2);
                Debug.Log($"урон по врагу {PlayerParametrs.DamageWeapon3_2}");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (isBigWord)
            {
                enemy.TakeDamage(PlayerParametrs.DamageWeapon3);
                Debug.Log($"урон по врагу {PlayerParametrs.DamageWeapon3} coll");
            }
            else
            {
                enemy.TakeDamage(PlayerParametrs.DamageWeapon3_2);
                Debug.Log($"урон по врагу {PlayerParametrs.DamageWeapon3_2} coll");
            }
        }
    }
}
