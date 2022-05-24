using UnityEngine;

public class ShieldOfFaith : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(PlayerParametrs.DamageWeapon1Max + (int)(PlrMove.moveVelosity) *2);
            Debug.Log($"урон щитом по врагу {PlayerParametrs.DamageWeapon1Max + (int)(PlrMove.moveVelosity) * 2}");
        }
    }
}
