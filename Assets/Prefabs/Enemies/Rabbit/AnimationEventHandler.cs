using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    private Gob01Follow enemyScript;
    public EnemyAudio enemyAudio;
    private void  Start()
    {
        enemyScript = transform.GetComponentInParent<Gob01Follow>();
        enemyAudio = GameObject.Find("AudioEnemy").GetComponent<EnemyAudio>();
    }
    /// <summary>
    /// �� ����� �������� �����, ����� ������ ������ ���������� ���������� ��� ��������� �����
    /// </summary>
    private void OnAttack()
    {
        enemyScript.OnAttack();
    }
    /// <summary>
    /// � ����� �������� �����, ������ ���� ��� ����������� ��������
    /// </summary>
    private void EndAttack()
    {
        enemyScript.isAttacking = false;
    }
    /// <summary>
    /// � ����� �������� ������, �������� �������
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
