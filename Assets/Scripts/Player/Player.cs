using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        EventManager.TakeDamage(damage);
        Debug.Log($"take damage = {damage}");
    }

}
