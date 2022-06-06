using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField] private AudioSource steps;
    [SerializeField] private AudioSource attack;
    [SerializeField] private AudioSource death;

    [Header("AudioClipsAttack")]
    [SerializeField] private AudioClip attack1;
    [SerializeField] private AudioClip attack2;
    [SerializeField] private AudioClip attack3;

    [Header("AudioClipsDeath")]
    [SerializeField] private AudioClip[] deathClips;

    public void SoundSteps()
    {
        try
        {
            if (!steps.isPlaying)
                steps.Play();
        }
        catch
        {

        }

    }
    public void SoundDeath()
    {
        int randClip = Random.Range(0,4);
        death.PlayOneShot(deathClips[randClip]);
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
