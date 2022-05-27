using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource shoot;
    [SerializeField] private AudioSource move;

    public void ShootWeapon2()
    {
        shoot.Play();
    }

    public void Move()
    {
        move.Play();
    }
}
