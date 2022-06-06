using UnityEngine;

public class TriggerSoundSteps : MonoBehaviour
{
    [SerializeField] private EnemyAudio enemyAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == ("FootFinger_LP"))
        {
            enemyAudio.SoundSteps();
        }
    }
}
