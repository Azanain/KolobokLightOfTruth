using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    private Gob01Follow enemyScript;
    private EnemyAudio enemyAudio;
    private void  Start()
    {
        enemyScript = transform.GetComponentInParent<Gob01Follow>();   
        if (enemyAudio == null)
        {
            enemyAudio = GameObject.Find("AudioEnemy").GetComponent<EnemyAudio>();
        }
        if (enemyAudio == null)
        {
            enemyAudio = transform.parent.gameObject.GetComponent<EnemyAudio>();
        }
    }
    /// <summary>
    /// во время анимаций атаки, вызов метода поиска вражеского коллайдера для нанесения урона
    /// </summary>
    private void OnAttack()
    {
        enemyScript.OnAttack();
    }
    /// <summary>
    /// в конце анимации атаки, меняет буль для возможности движения
    /// </summary>
    private void EndAttack()
    {
        enemyScript.isAttacking = false;
    }
    /// <summary>
    /// в конде анимации смерти, удаление объекта
    /// </summary>
    private void Death()
    {
        enemyScript.Death();
    }
    private void SoundStep()
    {
        enemyAudio.SoundSteps();
    }
}
