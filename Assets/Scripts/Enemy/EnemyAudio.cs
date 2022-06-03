using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField] private AudioSource steps;
    [SerializeField] private AudioSource attack;
    [SerializeField] private AudioSource death;

    [Header("AudioClips")]
    [SerializeField] private AudioClip attack1;
    [SerializeField] private AudioClip attack2;
    [SerializeField] private AudioClip attack3;

    public void SoundSteps()
    {
        if (!steps.isPlaying)
            steps.Play();
    }
    public void SoundDeath()
    {
        death.Play();
    }
    public void SoundAttack(int numberSoundAttack)
    {
        switch (numberSoundAttack)
        {
            case 1:
                if(!attack.isPlaying)
                    attack.PlayOneShot(attack1);
                break;
            case 2:
                if (!attack.isPlaying)
                    attack.PlayOneShot(attack2);
                break;
            case 3:
                if (!attack.isPlaying)
                    attack.PlayOneShot(attack3);
                break;
        }
        
    }
}
