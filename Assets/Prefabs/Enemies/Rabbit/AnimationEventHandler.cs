using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    private Gob01Follow enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = transform.GetComponentInParent<Gob01Follow>();
        Debug.Log("Anim script started!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttackAnimationEnd()
    {
        enemyScript.OnAttack();
        Debug.Log("Attack!");
    }
}
